using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNBase.Objects;

namespace TNBase.DataStorage.Repository
{
    public class TNBaseRepository : IDisposable
    {
        public SQLiteConnection Connection { get; }

        public TNBaseRepository(string databasePath)
        {
            Connection = new SQLiteConnection(DBUtils.GenConnectionString(databasePath));
            Connection.Open();
        }

        public void AddScans(IEnumerable<Scan> scans)
        {
            using (var transaction = Connection.BeginTransaction())
            {
                foreach (var scan in scans)
                {
                    using (var command = Connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO Scans(Wallet, Type, WalletType, Recorded) VALUES($Wallet, $Type, $WalletType, $Recorded)";
                        command.Parameters.Add("$Wallet", DbType.Int32).Value = scan.Wallet;
                        command.Parameters.Add("$Type", DbType.String).Value = scan.ScanType.ToString();
                        command.Parameters.Add("$WalletType", DbType.String).Value = scan.WalletType.ToString();
                        command.Parameters.Add("$Recorded", DbType.DateTime).Value = DateTime.UtcNow;
                        command.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
            }
        }

        public void Dispose()
        {
            if (Connection != null)
                Connection.Close();
        }

        public IEnumerable<Scan> GetScans(DateTime from, DateTime until, ScanTypes scanType, WalletTypes walletType)
        {
            return new List<Scan>();
        }
    }
}
