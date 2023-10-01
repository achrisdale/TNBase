using System;
using TNBase.Infrastructure.Helpers;
using Xunit;

namespace TNBase.Domain.Test
{
    public class ListenerTests
    {
        private Listener CreateValidListener()
        {
            Listener listener = new Listener();

            listener.Title = "Mr";
            listener.Forename = "Ted";
            listener.Surname = "Baker";
            listener.Addr1 = "29 Baker Street";
            listener.Addr2 = "";
            listener.Postcode = "N193HH";
            listener.BirthdayDay = 1;
            listener.BirthdayMonth = 1;
            listener.County = "Londonshire";
            listener.InOutRecords = new InOutRecords();
            listener.MemStickPlayer = true;
            listener.LastIn = DateTime.Now;
            listener.LastOut = null;
            listener.Joined = DateTime.ParseExact("01/01/2015", DateHelpers.DEFAULT_DATE_FORMAT, null);
            listener.Magazine = false;
            listener.Status = ListenerStates.ACTIVE;
            listener.DeletedDate = DateTime.ParseExact("01/01/2015", DateHelpers.DEFAULT_DATE_FORMAT, null);
            listener.Telephone = "01234567890";
            listener.Town = "London";
            listener.Wallet = 0;

            return listener;
        }

        [Fact]
        public void Listener_DaysBeforeBirthday()
        {
            DateTime dateTime = DateTime.Now.AddDays(5);
            Assert.Equal(5, Listener.DaysUntilBirthday(dateTime));

            dateTime = DateTime.Now.AddDays(67);
            Assert.Equal(67, Listener.DaysUntilBirthday(dateTime));
        }

        [Fact]
        public void Listener_PauseTest()
        {
            Listener dummy = CreateValidListener();
            dummy.Status = ListenerStates.ACTIVE;

            // Pause with a never end date.
            DateTime startDate = DateTime.Now;
            dummy.Pause(startDate);

            Assert.Equal(ListenerStates.PAUSED, dummy.Status);
            Assert.Equal(startDate.DayOfYear, dummy.GetStoppedDate().DayOfYear);
            // Not expecting a resume date.
            Assert.Null(dummy.GetResumeDate());

            // Now pause them with an end date (+10 days).
            DateTime endDate = startDate.AddDays(10);
            dummy.Pause(startDate, endDate);

            Assert.Equal(ListenerStates.PAUSED, dummy.Status);
            Assert.Equal(startDate.DayOfYear, dummy.GetStoppedDate().DayOfYear);
            // Not expecting a resume date.
            Assert.Equal(endDate.DayOfYear, dummy.GetResumeDate().Value.DayOfYear);
        }

        [Fact]
        public void Listener_ResumeTest()
        {
            Listener dummy = CreateValidListener();
            dummy.Pause(DateTime.Now);
            dummy.Resume();

            Assert.Equal(ListenerStates.ACTIVE, dummy.Status);
            Assert.True(string.IsNullOrEmpty(dummy.StatusInfo), "Expected empty or null status info string.");
        }

        [Fact]
        public void Listener_ResumeActive()
        {
            Listener dummy = CreateValidListener();
            dummy.Status = ListenerStates.ACTIVE;

            Assert.Throws<ListenerStateChangeException>(() =>
                dummy.Resume()
            );
        }

        [Fact]
        public void Listener_PauseDeletedListener()
        {
            Listener dummy = CreateValidListener();
            dummy.Status = ListenerStates.DELETED;

            Assert.Throws<ListenerStateChangeException>(() =>
                dummy.Pause(DateTime.Now)
            );
        }

        [Fact]
        public void MagazineStock_ShouldBeSetToZero_WhenNewListenerIsCreated()
        {
            var listener = new Listener();

            Assert.Equal(0, listener.MagazineStock);
        }

        [Fact]
        public void GetNiceName_ReturnsName_WhenNoTitle()
        {
            var listener = new Listener
            {
                Title = "",
                Forename = "Bob",
                Surname = "Builder"
            };

            var result = listener.GetNiceName();

            Assert.Equal("Bob Builder", result);
        }

        [Fact]
        public void GetNiceName_ReturnsNameWithTitle_WhenTitleProvided()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder"
            };

            var result = listener.GetNiceName();

            Assert.Equal("Mr. Bob Builder", result);
        }

        [Fact]
        public void FormatListenerData_ReturnsOnlyListenerNiceName_WhenNoAddress()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder"
            };

            var result = listener.FormatListenerData();

            Assert.Equal("Mr. Bob Builder", result);
        }

        [Fact]
        public void FormatListenerData_ReturnsFirstLineAddressInSecondLine_WhenHasFirstLineAddress()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.Equal("Test House", lines[1]);
        }

        [Fact]
        public void FormatListenerData_ReturnsSecondLineAddressInSecondLine_WhenHasSecondLineAddress()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House",
                Addr2 = "Test Street"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.Equal("Test House, Test Street", lines[1]);
        }

        [Fact]
        public void FormatListenerData_ReturnsTownInThirdLine_WhenHasTown()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House",
                Addr2 = "Test Street",
                Town = "Test Town"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.Equal("Test Town", lines[2]);
        }

        [Fact]
        public void FormatListenerData_ReturnsCountyInThirdLine_WhenHasCounty()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House",
                Addr2 = "Test Street",
                Town = "Test Town",
                County = "Test County"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.Equal("Test Town, Test County", lines[2]);
        }

        [Fact]
        public void FormatListenerData_ReturnsPostcodeInFourthLine_WhenHasPostcode()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House",
                Addr2 = "Test Street",
                Town = "Test Town",
                County = "Test County",
                Postcode = "Test Postcode"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.Equal("Test Postcode", lines[3]);
        }

        [Fact]
        public void Delete_SetStatusToDeleted_WhenPlayerIsNotReturned()
        {
            var listener = new Listener
            {
                MemStickPlayer = true
            };

            listener.Delete("");
            Assert.Equal(ListenerStates.DELETED, listener.Status);
        }

        [Fact]
        public void Delete_SetStatusToDeleted_WhenListenerHoldsNewsWallet()
        {
            var listener = new Listener
            {
                Stock = 0,
            };

            listener.Delete("");
            Assert.Equal(ListenerStates.DELETED, listener.Status);
        }

        [Fact]
        public void Delete_SetStatusToDeleted_WhenListenerHoldsMagazineWallet()
        {
            var listener = new Listener
            {
                Stock = 3,
                Magazine = true,
                MagazineStock = 0
            };

            listener.Delete("");
            Assert.Equal(ListenerStates.DELETED, listener.Status);
        }

        [Fact]
        public void Delete_ClearsListenersPersonalInformation_WhenListenerIsPurged()
        {
            var listener = new Listener
            {
                Title = "Title",
                Forename = "Forename",
                Surname = "Surname",
                Addr1 = "Address1",
                Addr2 = "Address2",
                Town = "Town",
                County = "County",
                Postcode = "Postcode",
                Telephone = "123456789",
                BirthdayDay = 5,
                BirthdayMonth = 12,
                Info = "Test Info",
                StatusInfo = "Test Status Info"
            };

            listener.Delete("");

            Assert.Equal("N/A", listener.Title);
            Assert.Equal("Deleted", listener.Forename);
            Assert.Equal("Deleted", listener.Surname);
            Assert.Null(listener.Addr1);
            Assert.Null(listener.Addr2);
            Assert.Null(listener.Town);
            Assert.Null(listener.County);
            Assert.Null(listener.Postcode);
            Assert.Null(listener.Telephone);
            Assert.Null(listener.BirthdayDay);
            Assert.Null(listener.BirthdayMonth);
            Assert.Null(listener.Info);
            Assert.Null(listener.StatusInfo);
        }

        [Fact]
        public void Delete_MaintainsListenersPersonalInformation_WhenListenerIsDeleted()
        {
            var joinDate = DateTime.Now;

            var listener = new Listener
            {
                MemStickPlayer = true,
                Title = "Title",
                Forename = "Forename",
                Surname = "Surname",
                Addr1 = "Address1",
                Addr2 = "Address2",
                Town = "Town",
                County = "County",
                Postcode = "Postcode",
                Telephone = "123456789",
                Joined = joinDate,
                BirthdayDay = 5,
                BirthdayMonth = 12,
                Info = "Test Info"
            };

            listener.Delete("");

            Assert.Equal("Title", listener.Title);
            Assert.Equal("Forename", listener.Forename);
            Assert.Equal("Surname", listener.Surname);
            Assert.Equal("Address1", listener.Addr1);
            Assert.Equal("Address2", listener.Addr2);
            Assert.Equal("Town", listener.Town);
            Assert.Equal("County", listener.County);
            Assert.Equal("Postcode", listener.Postcode);
            Assert.Equal("123456789", listener.Telephone);
            Assert.Equal(joinDate, listener.Joined);
            Assert.Equal(5, listener.BirthdayDay);
            Assert.Equal(12, listener.BirthdayMonth);
            Assert.Equal("Test Info", listener.Info);
        }

        [Fact]
        public void Delete_SetsCorrectDeletedDate_WhenListenerIsDeleted()
        {
            var listener = new Listener();

            var before = DateTime.UtcNow;
            listener.Delete("");
            var after = DateTime.UtcNow;

            Assert.True(before <= listener.DeletedDate, "Date is greater or equal to before");
            Assert.True(after >= listener.DeletedDate, "Date is less or equal to after");
        }

        [Fact]
        public void Delete_SetsCorrectDeletedDate_WhenListenerIsPurged()
        {
            var listener = new Listener
            {
                MemStickPlayer = true
            };

            var before = DateTime.UtcNow;
            listener.Delete("");
            var after = DateTime.UtcNow;

            Assert.True(before <= listener.DeletedDate, "Date is greater or equal to before");
            Assert.True(after >= listener.DeletedDate, "Date is less or equal to after");
        }

        [Fact]
        public void Delete_SetsReason_WhenListenerIsDeleted()
        {
            var listener = new Listener
            {
                MemStickPlayer = true
            };

            listener.Delete("Delete reason");

            Assert.Equal("Delete reason", listener.StatusInfo);
        }

        [Fact]
        public void Delete_SetsReason_WhenListenerIsPurged()
        {
            var listener = new Listener
            {
                MemStickPlayer = true
            };

            listener.Delete("Delete reason");

            Assert.Equal("Delete reason", listener.StatusInfo);
        }

        [Fact]
        public void Restore_SetsStatusToActive_WhenListenerIsDeleted()
        {
            var listener = new Listener
            {
                Status = ListenerStates.DELETED
            };

            listener.Restore();

            Assert.Equal(ListenerStates.ACTIVE, listener.Status);
        }

        [Fact]
        public void Restore_ClearsStatusInfo()
        {
            var listener = new Listener
            {
                Status = ListenerStates.DELETED,
                StatusInfo = "Deleted"
            };

            listener.Restore();

            Assert.Equal("", listener.StatusInfo);
        }

        [Fact]
        public void Restore_ClearsDeletedDate()
        {
            var listener = new Listener
            {
                Status = ListenerStates.DELETED,
                DeletedDate = DateTime.UtcNow
            };

            listener.Restore();

            Assert.Null(listener.DeletedDate);
        }

        [Fact]
        public void Restore_ThrowsSatusChangeException_WhenListenerIsActive()
        {
            var listener = new Listener
            {
                Status = ListenerStates.ACTIVE
            };

            Assert.Throws<ListenerStateChangeException>(() =>
                listener.Restore()
            );
        }

        [Fact]
        public void Restore_ThrowsSatusChangeException_WhenListenerIsPaused()
        {
            var listener = new Listener
            {
                Status = ListenerStates.PAUSED
            };

            Assert.Throws<ListenerStateChangeException>(() =>
                listener.Restore()
            );
        }

        [Fact]
        public void SentNewsWallets_ReturnsZero_WhenAllNewsWalletsAreInStock()
        {
            var listener = new Listener { Stock = 2, NewsWalletsIssued = 2 };

            Assert.Equal(0, listener.SentNewsWallets);
        }

        [Fact]
        public void SentNewsWallets_ReturnsNumberOfSentWallets_WhenNotAllNewsWalletsAreInStock()
        {
            var listener = new Listener { Stock = 1, NewsWalletsIssued = 5 };

            Assert.Equal(4, listener.SentNewsWallets);
        }

        [Fact]
        public void SentMagazineWallets_ReturnsZero_WhenMagazineWalletIsInStock()
        {
            var listener = new Listener { MagazineStock = 2, Magazine = true, MagazineWalletsIssued = 2 };

            Assert.Equal(0, listener.SentMagazineWallets);
        }

        [Fact]
        public void SentMagazineWallets_ReturnsNumberOfSentWallets_WhenNoMagazineWalletIsInStock()
        {
            var listener = new Listener { MagazineStock = 0, Magazine = true, MagazineWalletsIssued = 2 };

            Assert.Equal(2, listener.SentMagazineWallets);
        }

        [Fact]
        public void SentMagazineWallets_ReturnsZero_WhenMagazineOptionIsNotSet()
        {
            // TODO: Review if this logic is OK. I would think magazine checkbox should not influence this value
            var listener = new Listener { MagazineStock = 0, Magazine = false, MagazineWalletsIssued = 2 };

            Assert.Equal(0, listener.SentMagazineWallets);
        }

        [Fact]
        public void Scan_PurgesListener_WhenDeletedListenerLastNewsWalletIsReturned()
        {
            var listener = new Listener
            {
                Forename = "Listener",
                Stock = 2,
                NewsWalletsIssued = 3,
                Status = ListenerStates.DELETED
            };

            listener.Scan(ScanTypes.IN, WalletTypes.News);

            Assert.True(listener.IsAnonymized);
        }

        [Fact]
        public void Scan_PurgesListener_WhenDeletedListenerLastMagazineWalletIsReturned()
        {
            var listener = new Listener
            {
                Forename = "Listener",
                Magazine = true,
                MagazineStock = 0,
                MagazineWalletsIssued = 1,
                Status = ListenerStates.DELETED
            };

            listener.Scan(ScanTypes.IN, WalletTypes.Magazine);

            Assert.True(listener.IsAnonymized);
        }
    }
}
