using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SQLite;
using TNBase.DataStorage.Test.TestHelpers;
using TNBase.Objects;
using System.Collections.Generic;
using TNBase.DataStorage.Migrations;

namespace TNBase.DataStorage.Test
{
    [DeploymentItem(@"x86\SQLite.Interop.dll", "x86")] // this is the key
    [DeploymentItem("Listeners.s3db")]
    [TestClass]
    public class RepoStorage_Tests
    {
        SQLiteConnection connection = null;
        RepositoryLayer repoLayer = new RepositoryLayer();

        [TestInitialize]
        public void Setup()
        {
            // setup connection
            if (connection == null)
            {
                connection = new SQLiteConnection(DBUtils.GenConnectionString(":memory:"));
                connection.Open();
                CreateTables(connection);
                new DatabaseUpdater<SqlMigration>(connection).Update();
            }
        }

        private void CreateTables(SQLiteConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"CREATE TABLE [Collectors] ([Key] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Forename] text NULL, " +
                    "[Surname] text NULL, [Telephone] text NULL, [Postcodes] text NULL)";
                command.ExecuteNonQuery();

                command.CommandText = $"CREATE TABLE [Listeners] ([Wallet] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Title] text NULL, " +
                    "[Forename] text NOT NULL, [Surname] text NOT NULL, [Addr1] text NULL, [Addr2] text NULL, [Town] text NULL, [County] text NULL, " +
                    "[Postcode] text NULL, [Magazine] bit NULL, [MemStickPlayer] bit NULL, [Telephone] text NULL, [Joined] date NULL, " +
                    "[Birthday] date NULL, [Info] text NULL, [Status] text DEFAULT('Active') NULL, [StatusInfo] text NULL, [In1] bigint DEFAULT(0) NULL, " +
                    "[In2] bigint DEFAULT(0) NULL, [In3] bigint DEFAULT(0) NULL, [In4] bigint DEFAULT(0) NULL, [In5] bigint DEFAULT(0) NULL, " +
                    "[In6] bigint DEFAULT(0) NULL, [In7] bigint DEFAULT(0) NULL, [In8] bigint DEFAULT(0) NULL, [Out1] bigint DEFAULT(0) NULL, " +
                    "[Out2] bigint DEFAULT(0) NULL, [Out3] bigint DEFAULT(0) NULL, [Out4] bigint DEFAULT(0) NULL, [Out5] bigint DEFAULT(0) NULL, " +
                    "[Out6] bigint DEFAULT(0) NULL, [Out7] bigint DEFAULT(0) NULL, [Out8] bigint DEFAULT(0) NULL, [DeletedDate] date NULL, " +
                    "[Stock] bigint DEFAULT(3) NULL, [LastIn] date NULL, [LastOut] date NULL)";
                command.ExecuteNonQuery();

                command.CommandText = $"CREATE TABLE [Scans] ([Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Wallet] bigint NOT NULL, " +
                    "[Type] text NOT NULL, [Recorded] date DEFAULT(CURRENT_DATE) NULL)";
                command.ExecuteNonQuery();

                command.CommandText = $"CREATE UNIQUE INDEX [Scans_sqlite_autoindex_Scans_1] ON [Scans] ([Id] ASC)";
                command.ExecuteNonQuery();

                command.CommandText = $"CREATE TABLE [WeekStats] ([WeekNumber] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, " +
                    "[ScannedIn] bigint DEFAULT('0') NULL, [ScannedOut] bigint DEFAULT('0') NULL, [PausedCount] bigint DEFAULT('0') NOT NULL, " +
                    "[TotalListeners] bigint DEFAULT('0') NULL, [Date] date DEFAULT(CURRENT_DATE) NULL)";
                command.ExecuteNonQuery();

                command.CommandText = $"CREATE TABLE [YearStats] ([Year] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, " +
                    "[StartListeners] bigint DEFAULT('0') NULL, [EndListeners] bigint DEFAULT('0') NULL, [NewListeners] bigint DEFAULT('0') NULL, " +
                    "[DeletedListeners] bigint DEFAULT('0') NULL, [AverageListeners] bigint DEFAULT('0') NULL, [InactiveTotal] bigint DEFAULT('0') NULL, " +
                    "[MagazineTotal] bigint DEFAULT('0') NULL, [AverageSent] bigint DEFAULT('0') NULL, [SentTotal] bigint DEFAULT('0') NULL, " +
                    "[MagazinesSent] bigint DEFAULT('0') NULL, [PercentSent] bigint DEFAULT('0') NULL, [MemStickPlayerLoanTotal] bigint DEFAULT('0') NULL, " +
                    "[PausedTotal] bigint DEFAULT('0') NULL, [AveragePaused] bigint DEFAULT('0') NULL, [DeletedTotal] bigint DEFAULT('0') NULL)";
                command.ExecuteNonQuery();

                command.CommandText = $"CREATE UNIQUE INDEX [YearStats_sqlite_autoindex_YearStats_1] ON [YearStats] ([Year] ASC)";
                command.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        [TestMethod]
        public void Repo_Listener_Tests()
        {
            Listener toInsert = CreateExtensions.DummyListener();

            // Insert the listener
            int retWallet = repoLayer.InsertListener(connection, toInsert);
            Assert.AreEqual(1, retWallet);

            // Edit and re-insert.
            toInsert.Forename = "New";
            toInsert.Surname = "Man";
            toInsert.Wallet = 2;
            retWallet = repoLayer.InsertListener(connection, toInsert);
            Assert.AreEqual(2, retWallet);

            // Check the results
            List<Listener> results = repoLayer.GetListeners(connection);
            Assert.AreEqual(2, results.Count);

            Assert.AreEqual(CreateExtensions.DummyListener().Serialize(), results[0].Serialize());
            Assert.AreEqual(toInsert.Serialize(), results[1].Serialize());

            // Update one of the listeners
            toInsert.Forename = "Updated";
            repoLayer.UpdateListener(connection, toInsert);

            // Check the results
            results = repoLayer.GetListeners(connection);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(CreateExtensions.DummyListener().Serialize(), results[0].Serialize());
            Assert.AreEqual(toInsert.Serialize(), results[1].Serialize());

            // Delete a listener
            repoLayer.DeleteListener(connection, results[0]);

            // Check the results
            results = repoLayer.GetListeners(connection);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(toInsert.Serialize(), results[0].Serialize());
        }

        [TestMethod]
        public void Repo_Collector_Tests()
        {
            Collector toInsert = CreateExtensions.DummyCollector();

            // Insert the collector
            repoLayer.InsertCollector(connection, toInsert);

            // Edit and re-insert.
            toInsert.Forename = "New";
            toInsert.Surname = "Man";
            toInsert.ID = 2;
            repoLayer.InsertCollector(connection, toInsert);

            // Check the results
            List<Collector> results = repoLayer.GetCollectors(connection);
            Assert.AreEqual(2, results.Count);

            Assert.AreEqual(CreateExtensions.DummyCollector().Serialize(), results[0].Serialize());
            Assert.AreEqual(toInsert.Serialize(), results[1].Serialize());

            // Update one of the listeners
            results[1].Forename = "Updated";
            Collector updated = results[1];
            repoLayer.UpdateCollector(connection, updated);

            // Check the results
            results = repoLayer.GetCollectors(connection);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(CreateExtensions.DummyCollector().Serialize(), results[0].Serialize());
            Assert.AreEqual(updated.Serialize(), results[1].Serialize());

            // Delete a listener
            repoLayer.DeleteCollector(connection, results[1]);

            // Check the results
            results = repoLayer.GetCollectors(connection);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(CreateExtensions.DummyCollector().Serialize(), results[0].Serialize());
        }

        [TestMethod]
        public void Repo_YearStats_Tests()
        {
            YearStats toInsert = CreateExtensions.DummyYearStats();

            // Insert the year stats
            repoLayer.InsertYearStats(connection, toInsert);

            // Edit and re-insert.
            toInsert.MemStickPlayerLoanTotal = 1000;
            toInsert.Year = 2017;
            repoLayer.InsertYearStats(connection, toInsert);

            // Check the results
            List<YearStats> results = repoLayer.GetYearStats(connection);
            Assert.AreEqual(2, results.Count);

            Assert.AreEqual(CreateExtensions.DummyYearStats().Serialize(), results[0].Serialize());
            Assert.AreEqual(toInsert.Serialize(), results[1].Serialize());

            // Update one of the listeners
            results[1].AvListeners = 19;
            YearStats updated = results[1];
            repoLayer.UpdateYearStats(connection, updated);

            // Check the results
            results = repoLayer.GetYearStats(connection);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(CreateExtensions.DummyYearStats().Serialize(), results[0].Serialize());
            Assert.AreEqual(updated.Serialize(), results[1].Serialize());

            // Delete a listener
            repoLayer.DeleteYearStats(connection, results[1]);

            // Check the results
            results = repoLayer.GetYearStats(connection);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(CreateExtensions.DummyYearStats().Serialize(), results[0].Serialize());
        }

        [TestMethod]
        public void Repo_WeekStats_Tests()
        {
            WeeklyStats toInsert = CreateExtensions.DummyWeekStats();

            // Insert the weekly stats
            repoLayer.InsertWeeklyStats(connection, toInsert);

            // Edit and re-insert.
            toInsert.TotalListeners = 1000;
            toInsert.WeekNumber = 2;
            repoLayer.InsertWeeklyStats(connection, toInsert);

            // Check the results
            List<WeeklyStats> results = repoLayer.GetWeeklyStats(connection);
            Assert.AreEqual(2, results.Count);

            Assert.AreEqual(CreateExtensions.DummyWeekStats().Serialize(), results[0].Serialize());
            Assert.AreEqual(toInsert.Serialize(), results[1].Serialize());

            // Update one of the listeners
            results[1].ScannedOut = 19;
            WeeklyStats updated = results[1];
            repoLayer.UpdateWeeklyStats(connection, updated);

            // Check the results
            results = repoLayer.GetWeeklyStats(connection);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(CreateExtensions.DummyWeekStats().Serialize(), results[0].Serialize());
            Assert.AreEqual(updated.Serialize(), results[1].Serialize());

            // Delete a listener
            repoLayer.DeleteWeeklyStats(connection, results[1]);

            // Check the results
            results = repoLayer.GetWeeklyStats(connection);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(CreateExtensions.DummyWeekStats().Serialize(), results[0].Serialize());
        }

        [TestMethod]
        public void Repo_NextFreeIndex_Tests()
        {
            Listener toInsert = CreateExtensions.DummyListener();
            toInsert.Wallet = 1;
            repoLayer.InsertListener(connection, toInsert);
            toInsert.Wallet = 2;
            repoLayer.InsertListener(connection, toInsert);
            toInsert.Wallet = 3;
            repoLayer.InsertListener(connection, toInsert);
            toInsert.Wallet = 4;
            repoLayer.InsertListener(connection, toInsert);
            toInsert.Wallet = 5;
            repoLayer.InsertListener(connection, toInsert);

            Assert.AreEqual(6, repoLayer.CalculateNextFreeWallet(connection));

            toInsert.Wallet = 6;
            repoLayer.InsertListener(connection, toInsert);
            toInsert.Wallet = 8;
            repoLayer.InsertListener(connection, toInsert);
            toInsert.Wallet = 9;
            repoLayer.InsertListener(connection, toInsert);
            toInsert.Wallet = 11;
            repoLayer.InsertListener(connection, toInsert);

            Assert.AreEqual(7, repoLayer.CalculateNextFreeWallet(connection));
        }

        [TestMethod]
        public void Repo_ClearAllData()
        {
            repoLayer.InsertCollector(connection, CreateExtensions.DummyCollector());
            repoLayer.InsertListener(connection, CreateExtensions.DummyListener());
            repoLayer.InsertWeeklyStats(connection, CreateExtensions.DummyWeekStats());
            repoLayer.InsertYearStats(connection, CreateExtensions.DummyYearStats());

            Assert.AreEqual(1, repoLayer.GetListeners(connection).Count);
            Assert.AreEqual(1, repoLayer.GetCollectors(connection).Count);
            Assert.AreEqual(1, repoLayer.GetWeeklyStats(connection).Count);
            Assert.AreEqual(1, repoLayer.GetYearStats(connection).Count);

            repoLayer.ClearAllData(connection);

            Assert.AreEqual(0, repoLayer.GetListeners(connection).Count);
            Assert.AreEqual(0, repoLayer.GetCollectors(connection).Count);
            Assert.AreEqual(0, repoLayer.GetWeeklyStats(connection).Count);
            Assert.AreEqual(0, repoLayer.GetYearStats(connection).Count);
        }

        [TestMethod]
        public void Repo_TestScans()
        {
            IServiceLayer serviceLayer = new ServiceLayer(":memory:", repoLayer);
            serviceLayer.EnsureScanTableExists();

            Assert.AreEqual(0, repoLayer.GetScanRecords(connection).Count);

            Scan temp = new Scan();
            temp.Wallet = 10;
            temp.ScanType = ScanTypes.OUT;
            temp.WalletType = WalletTypes.Magazine;

            repoLayer.InsertScan(connection, temp);

            Assert.AreEqual(1, repoLayer.GetScanRecords(connection).Count);

            Assert.AreEqual(10, repoLayer.GetScanRecords(connection)[0].Wallet);
            Assert.AreEqual(ScanTypes.OUT, repoLayer.GetScanRecords(connection)[0].ScanType);
            Assert.AreEqual(WalletTypes.Magazine, repoLayer.GetScanRecords(connection)[0].WalletType);

            repoLayer.DeleteScans(connection, 10);

            Assert.AreEqual(0, repoLayer.GetScanRecords(connection).Count);
        }
    }
}
