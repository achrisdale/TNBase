using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TNBase.DataStorage.Repository;
using TNBase.DataStorage.Test.TestHelpers;
using TNBase.Objects;

namespace TNBase.DataStorage.Test.Repository
{
    [TestClass]
    public class TNBaseRepositoryTests
    {
        [TestMethod]
        public void AddScans_ShouldAddAllScans()
        {
            var scans = new List<Scan>
            {
                new Scan
                {
                    Wallet = 1,
                    ScanType = ScanTypes.IN,
                    WalletType = WalletTypes.News
                },
                new Scan
                {
                    Wallet = 2,
                    ScanType = ScanTypes.OUT,
                    WalletType = WalletTypes.Magazine
                }
            };

            using (var repository = new TNBaseRepository(":memory:"))
            {
                DatabaseHelper.CreateDatabase(repository.Connection);

                repository.AddScans(scans);

                var before = DateTime.UtcNow;
                var result = GetScans(repository.Connection);
                var after = DateTime.UtcNow;

                Assert.AreEqual(2, result.Count());

                Assert.AreEqual(1, result.First().Wallet);
                Assert.AreEqual(ScanTypes.IN, result.First().ScanType);
                Assert.AreEqual(WalletTypes.News, result.First().WalletType);
                Assert.IsTrue(before <= result.First().Recorded, "Date is greater or equal to before");
                Assert.IsTrue(after >= result.First().Recorded, "Date is less or equal to after");

                Assert.AreEqual(2, result.Last().Wallet);
                Assert.AreEqual(ScanTypes.OUT, result.Last().ScanType);
                Assert.AreEqual(WalletTypes.Magazine, result.Last().WalletType);
                Assert.IsTrue(before <= result.Last().Recorded, "Date is greater or equal to before");
                Assert.IsTrue(after >= result.Last().Recorded, "Date is less or equal to after");
            }
        }

        private IEnumerable<Scan> GetScans(SQLiteConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Scans";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Enum.TryParse(reader["Type"].ToString(), true, out ScanTypes scanType);
                        Enum.TryParse(reader["WalletType"].ToString(), true, out WalletTypes walletType);

                        yield return new Scan
                        {
                            Wallet = Convert.ToInt32(reader["Wallet"]),
                            ScanType = scanType,
                            WalletType = walletType,
                            Recorded = Convert.ToDateTime(reader["Recorded"]),
                        };
                    }
                }
            }
        }
    }
}
