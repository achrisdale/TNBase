using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TNBase.Objects
{
    [Table("Listeners")]
    public class Listener
    {
        public const string NEVER_END_PAUSE_STRING = "UFN";
        public const int DEFAULT_STOCK = 3;

        public Listener()
        {
            Joined = DateTime.Now;
            Stock = DEFAULT_STOCK;
            Status = ListenerStates.ACTIVE;
        }

        [Key]
        public int Wallet { get; set; }
        public string Title { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Telephone { get; set; }
        public bool MemStickPlayer { get; set; }
        public bool Magazine { get; set; }
        public DateTime? Birthday { get; set; }
        [XmlIgnore]
        public DateTime? Joined { get; set; }
        public string Info { get; set; }
        [Column("Status")]
        public string State { get; set; }
        [NotMapped]
        public ListenerStates Status
        {
            get
            {
                Enum.TryParse<ListenerStates>(State, out var status);
                return status;
            }
            set
            {
                State = value.ToString();
            }
        }
        public string StatusInfo { get; set; }
        [Required]
        public virtual InOutRecords inOutRecords { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int Stock { get; set; }
        public DateTime? LastIn { get; set; }
        public DateTime? LastOut { get; set; }
        public int MagazineStock { get; set; }

        public string GetNiceName()
        {
            var nameParts = new List<string> { Title, Forename, Surname }
                .Where(x => !string.IsNullOrWhiteSpace(x));
            return string.Join(" ", nameParts);
        }

        public static int DaysUntilBirthday(DateTime birthday)
        {
            var nextBirthday = birthday.AddYears(DateTime.Today.Year - birthday.Year);
            if (nextBirthday < DateTime.Today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }
            return (nextBirthday - DateTime.Today).Days;
        }

        public DateTime GetStoppedDate()
        {
            if (Status == ListenerStates.PAUSED)
            {
                var stoppedDate = StatusInfo.Substring(0, StatusInfo.IndexOf(","));
                return DateTime.Parse(stoppedDate);
            }

            return DateTime.Now;
        }

        public void Pause(DateTime startDate, DateTime? endDate = null)
        {
            if (Status == ListenerStates.DELETED)
            {
                throw new ListenerStateChangeException();
            }

            Status = ListenerStates.PAUSED;

            var myDateStr = endDate == null ? NEVER_END_PAUSE_STRING : endDate.Value.ToNiceStr();
            StatusInfo = startDate.ToNiceStr() + "," + myDateStr;
        }

        public bool CanDeletePersonalData()
        {
            return !MemStickPlayer;
        }

        public void DeletePersonalData()
        {
            if (!CanDeletePersonalData())
            {
                throw new ListenerStateChangeException($"Can't delete listener's {Wallet} data as memory stick player has not been returned.");
            }

            Status = ListenerStates.DELETED;
            Title = "N/A";
            Forename = "Deleted";
            Surname = "Deleted";
            Addr1 = null;
            Addr2 = null;
            Town = null;
            County = null;
            Postcode = null;
            DeletedDate = DateTime.UtcNow;
            Telephone = null;
            Joined = null;
            Birthday = null;
            Info = null;
        }

        public void Delete()
        {
            if (CanDeletePersonalData())
            {
                DeletePersonalData();
            }
            else
            {
                Status = ListenerStates.DELETED;
            }
        }


        public void Resume()
        {
            if (Status != ListenerStates.PAUSED)
            {
                throw new ListenerStateChangeException();
            }

            Status = ListenerStates.ACTIVE;
            StatusInfo = "";
        }

        public DateTime? GetResumeDate()
        {
            if (Status == ListenerStates.PAUSED)
            {
                string resumeDate = StatusInfo.Substring(StatusInfo.IndexOf(",") + 1);
                if (resumeDate != NEVER_END_PAUSE_STRING)
                {
                    return DateTime.Parse(resumeDate);
                }
            }

            return null;
        }

        public string GetResumeDateString()
        {
            var result = GetResumeDate();
            return result.HasValue ? result.Value.ToNiceStr() : NEVER_END_PAUSE_STRING;
        }

        public DateTime BirthdayThisYear()
        {
            return Birthday.Value.AddYears(DateTime.Now.Year - Birthday.Value.Year);
        }

        public string FormatListenerData()
        {
            var builder = new StringBuilder();
            builder.Append(GetNiceName());

            if (Addr1 != null)
            {
                builder.AppendLine();
                builder.Append(FormatAddress());
            }

            return builder.ToString();
        }

        private string FormatAddress()
        {
            var builder = new StringBuilder();
            if (Addr1 != null)
            {
                var address = Addr1;
                if (Addr2 != null)
                {
                    address += ", " + Addr2;
                }
                builder.AppendLine(address);

                if (Town != null)
                {
                    var addressScondLine = Town;
                    if (County != null)
                    {
                        addressScondLine += ", " + County;
                    }
                    builder.AppendLine(addressScondLine);
                }

                if (Postcode != null)
                {
                    builder.AppendLine(Postcode);
                }
            }
            return builder.ToString();
        }

        public bool HasPausePeriodElapsed()
        {
            var resumeDate = GetResumeDate();
            return resumeDate.HasValue && resumeDate.Value < DateTime.Now;
        }
    }
}
