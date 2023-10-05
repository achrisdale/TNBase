using TNBase.Domain;
using System;
using FluentAssertions;
using TNBase.Repository;
using TNBase.Infrastructure.Helpers;

namespace TNBase.App.Test
{
    public class ServiceLayerTests
    {
        private readonly ServiceLayer serviceLayer;

        public ServiceLayerTests()
        {
            var contex = new TNBaseContext("Data Source=:memory:");
            contex.UpdateDatabase();
            serviceLayer = new ServiceLayer(contex);
            // Insert some data.
            InsertListeners();
            InsertCollectors();
            InsertWeeklyStats();
            InsertYearStats();
        }

        //[TestCleanup]
        //public void TestCleanup()
        //{
        //    // Clear data
        //    repoLayer.ClearAllData(serviceLayer.GetConnection());
        //    serviceLayer.GetConnection().Close();
        //}

        private void InsertYearStats()
        {
            YearStats y1 = new YearStats() { AveragePaused = 1, AverageSent = 2, AverageListeners = 3, DeletedListeners = 4, DeletedTotal = 5, EndListeners = 6, InactiveTotal = 7, MagazinesSent = 8, MagazineTotal = 9, MemStickPlayerLoanTotal = 10, NewListeners = 11, PausedTotal = 12, PercentSent = 13, SentTotal = 14, StartListeners = 15, Year = 2016 };
            serviceLayer.SaveYearStats(y1);
            YearStats y2 = new YearStats() { AveragePaused = 21, AverageSent = 22, AverageListeners = 23, DeletedListeners = 24, DeletedTotal = 25, EndListeners = 26, InactiveTotal = 27, MagazinesSent = 28, MagazineTotal = 29, MemStickPlayerLoanTotal = 30, NewListeners = 31, PausedTotal = 32, PercentSent = 33, SentTotal = 34, StartListeners = 35, Year = 2017 };
            serviceLayer.SaveYearStats(y2);
        }

        private void InsertWeeklyStats()
        {
            // Add past stats
            WeeklyStats p1 = new WeeklyStats() { WeekNumber = 1, PausedCount = 4, ScannedIn = 4, ScannedOut = 4, TotalListeners = 4, WeekDate = DateTime.ParseExact("01/01/2009", DateHelpers.DEFAULT_DATE_FORMAT, null) };
            serviceLayer.SaveWeekStats(p1);
            WeeklyStats p2 = new WeeklyStats() { WeekNumber = 2, PausedCount = 5, ScannedIn = 5, ScannedOut = 4, TotalListeners = 5, WeekDate = DateTime.ParseExact("12/12/2009", DateHelpers.DEFAULT_DATE_FORMAT, null) };
            serviceLayer.SaveWeekStats(p2);

            // Add some stats
            WeeklyStats w1 = new WeeklyStats() { WeekNumber = 3, PausedCount = 1, ScannedIn = 10, ScannedOut = 10, TotalListeners = 15, WeekDate = DateTime.Now };
            serviceLayer.SaveWeekStats(w1);
            WeeklyStats w2 = new WeeklyStats() { WeekNumber = 4, PausedCount = 2, ScannedIn = 15, ScannedOut = 12, TotalListeners = 16, WeekDate = DateTime.Now };
            serviceLayer.SaveWeekStats(w2);
            WeeklyStats w3 = new WeeklyStats() { WeekNumber = 5, PausedCount = 3, ScannedIn = 20, ScannedOut = 14, TotalListeners = 17, WeekDate = DateTime.Now };
            serviceLayer.SaveWeekStats(w3);
        }

        private void InsertCollectors()
        {
            // Add some collectors
            Collector c1 = new Collector() { Number = "01234", Forename = "Ted", Surname = "Dob", Postcodes = "N7N [A-C],N78 [S-T]" };
            serviceLayer.AddCollector(c1);
            Collector c2 = new Collector() { Number = "02324", Forename = "Yov", Surname = "Vid", Postcodes = "N1BB,N192 [A-C]" };
            serviceLayer.AddCollector(c2);
        }

        private void InsertListeners()
        {
            // Add some active listeners
            Listener l1 = new Listener() { Title = "Mr", Forename = "John", Surname = "Biddle", Addr1 = "1 Park Avenue", Addr2 = "", County = "London", Postcode = "N7 NDF", Town = "Camden", Telephone = "01234 423 232", Stock = 3, Info = "", Joined = DateTime.Now, MemStickPlayer = false, Magazine = true, Status = ListenerStates.ACTIVE, StatusInfo = "", LastOut = DateTime.Now.AddMonths(-2), Wallet = 1, InOutRecords = new InOutRecords(), BirthdayDay = 1, BirthdayMonth = 4 };
            serviceLayer.AddListener(l1);
            Listener l2 = new Listener() { Title = "Miss", Forename = "Sarah", Surname = "Jones", Addr1 = "40 Camden Road", Addr2 = "", County = "London", Postcode = "N7 8AB", Town = "Camden", Telephone = "07843434343", Stock = 3, Info = "", Joined = DateTime.Now, MemStickPlayer = true, Magazine = true, Status = ListenerStates.ACTIVE, StatusInfo = "", LastOut = DateTime.Now.AddMonths(-4), Wallet = 2, InOutRecords = new InOutRecords(), BirthdayDay = 7, BirthdayMonth = 5 };
            serviceLayer.AddListener(l2);

            // Add a deleted listener
            Listener l3 = new Listener() { Title = "Doctor", Forename = "Nigel", Surname = "Sarage", Addr1 = "4 Bad Lane", Addr2 = "Topal", County = "Coart", Postcode = "N7 8DD", Town = "Rhywr", Telephone = "01435 643633", Stock = 3, Info = "", Joined = DateTime.Now, MemStickPlayer = true, Magazine = true, Status = ListenerStates.ACTIVE, StatusInfo = "", LastOut = DateTime.Now.AddMonths(-4), Wallet = 3, InOutRecords = new InOutRecords(), BirthdayDay = 30, BirthdayMonth = 6 };
            // TODO (L) Improve/Change the delete method!
            serviceLayer.AddListener(l3);
            serviceLayer.SoftDeleteListener(l3, "Test");

            // Add a paused listener
            Listener l4 = new Listener() { Title = "Mrs", Forename = "Lazy", Surname = "Bones", Addr1 = "4 Bone Road", Addr2 = "Scel", County = "Etal", Postcode = "N19 2DD", Town = "Death", Telephone = "01435 643433", Stock = 3, Info = "", Joined = DateTime.Now.AddDays(-425), MemStickPlayer = false, Magazine = false, Status = ListenerStates.ACTIVE, StatusInfo = "", Wallet = 4, InOutRecords = new InOutRecords(), BirthdayDay = 15, BirthdayMonth = 12 };
            l4.Pause(DateTime.Now);
            serviceLayer.AddListener(l4);

            // Add a paused listener
            Listener l5 = new Listener() { Title = "Mr", Forename = "Bob", Surname = "Baker", Addr1 = "4 Bone Road", Addr2 = "Scel", County = "Etal", Postcode = "N19 2DD", Town = "Death", Telephone = "01435 643433", Stock = 3, Info = "", Joined = DateTime.Now.AddDays(-425), MemStickPlayer = false, Magazine = false, Status = ListenerStates.RESERVED, ReservedDate = DateTime.Now.AddDays(-20), StatusInfo = "", Wallet = 5, InOutRecords = new InOutRecords(), BirthdayDay = 15, BirthdayMonth = 12 };
            serviceLayer.AddListener(l5);
        }

        [Fact]
        public void Stats_GetListenersAtYearStart()
        {
            serviceLayer.GetListenersAtYearStart(2010).Should().Be(5);
        }

        [Fact]
        public void Stats_WeeklyListenersToday()
        {
            serviceLayer.GetCurrentListenerCount().Should().Be(3);
        }

        [Fact]
        public void Stats_NewListenersThisYear()
        {
            // Two of the listeners joined today
            serviceLayer.GetNewListenersForYear(DateTime.Now.Year).Should().Be(2);
        }

        [Fact]
        public void Stats_UnsentWallets()
        {
            serviceLayer.GetUnsentListeners().Count.Should().Be(2);
        }

        [Fact]
        public void Stats_DeletedListenersThisYear()
        {
            serviceLayer.GetLostListenersForYear(DateTime.Now.Year).Should().Be(1);
        }

        [Fact]
        public void Stats_NetListenersThisYear()
        {
            serviceLayer.GetNetListenersForYear(DateTime.Now.Year).Should().Be(1);
        }

        [Fact]
        public void GetCurrentWeekNumber()
        {
            serviceLayer.GetCurrentWeekNumber().Should().Be(5);
        }

        //[TestMethod]
        //public void GetCurrentWeekNumber_ShouldBeNewWeek()
        //{
        //    List<WeeklyStats> stats = repoLayer.GetWeeklyStats(serviceLayer.GetConnection());
        //    repoLayer.ClearWeeklyStats(serviceLayer.GetConnection());

        //    foreach (WeeklyStats stat in stats)
        //    {
        //        stat.WeekDate = stat.WeekDate.AddDays(-8);
        //        repoLayer.InsertWeeklyStats(serviceLayer.GetConnection(), stat);
        //    }

        //    serviceLayer.GetCurrentWeekNumber().Should().Be(6);
        //}

        [Fact]
        public void Stats_TotalStoppedWallets()
        {
            serviceLayer.GetPausedListeners().Count.Should().Be(1);
        }

        [Fact]
        public void Stats_AverageStoppedWallets()
        {
            serviceLayer.GetAveragePausedWallets(DateTime.Now.Year).Should().Be(2);
        }

        [Fact]
        public void Stats_InactiveListeners()
        {
            serviceLayer.Get3MonthInactiveListeners().Should().Be(1);
        }

        [Fact]
        public void Stats_MemoryStickPlayersOnLoan()
        {
            serviceLayer.GetMemorySticksOnLoan().Should().Be(1);
        }

        [Fact]
        public void Stats_AverageWalletsSentPerWeek()
        {
            serviceLayer.GetAverageDispatchedWallets(DateTime.Now.Year).Should().Be(12);
        }

        [Fact]
        public void Stats_TotalWalletsSentForYear()
        {
            serviceLayer.GetWalletsDispatchedForYear(DateTime.Now.Year).Should().Be(81);
        }

        [Fact]
        public void Stats_AverageListenersPerWeek()
        {
            serviceLayer.GetAverageListenersForYear(DateTime.Now.Year).Should().Be(16);
        }

        [Fact]
        public void Stats_MemorySticksOnLoan()
        {
            serviceLayer.GetMemorySticksOnLoan().Should().Be(1);
        }

        [Fact]
        public void Stats_CurrentListenerCount()
        {
            serviceLayer.GetCurrentListenerCount().Should().Be(3);
        }

        [Fact]
        public void ServiceLayer_GetListenerByName()
        {
            //Listener l1 = new Listener() { Title = "Mr", Forename = "John", Surname = "Biddle", Addr1 = "1 Park Avenue", Addr2 = "", County = "London", Postcode = "N7 NDF", Town = "Camden", Telephone = "01234 423 232", Stock = 3, Info = "", Joined = DateTime.Now, MemStickPlayer = false, Magazine = true, Status = ListenerStates.ACTIVE, StatusInfo = "", LastOut = DateTime.Now.AddMonths(-2), Wallet = 5, InOutRecords = new InOutRecords() };
            //serviceLayer.AddListener(l1);
            Listener l = new Listener() { Title = "Miss", Forename = "Other", Surname = "Jones", Addr1 = "40 Camden Road", Addr2 = "", County = "London", Postcode = "N7 8AB", Town = "Camden", Telephone = "07843434343", Stock = 3, Info = "", Joined = DateTime.Now, MemStickPlayer = true, Magazine = true, Status = ListenerStates.ACTIVE, StatusInfo = "", LastOut = DateTime.Now.AddMonths(-4), Wallet = 16, InOutRecords = new InOutRecords() };
            serviceLayer.AddListener(l);

            Assert.Single(serviceLayer.GetListenersByName("John", "Biddle"));
            Assert.Empty(serviceLayer.GetListenersByName("John", "Biddle", "Master"));
            Assert.Single(serviceLayer.GetListenersByName("Sarah", "Jones", "Miss"));
            Assert.Equal(2, serviceLayer.GetListenersByName("*", "Jones").Count);
        }

        [Fact]
        public void ServiceLayer_GetUpcomingBirthdays()
        {
            Assert.Empty(serviceLayer.GetUpcomingBirthdays(new DateRange() { from = new DateTime(2023, 3, 1), to = new DateTime(2023, 3, 31) }));
            Assert.Equal(2, serviceLayer.GetUpcomingBirthdays(new DateRange() { from = new DateTime(2023, 4, 1), to = new DateTime(2023, 5, 7) }).Count);
            Assert.Single(serviceLayer.GetUpcomingBirthdays(new DateRange() { from = new DateTime(2023, 4, 1), to = new DateTime(2023, 5, 6) }));
            Assert.Empty(serviceLayer.GetUpcomingBirthdays(new DateRange() { from = new DateTime(2023, 4, 2), to = new DateTime(2023, 5, 6) }));

            // returns paused but not deleted listener
            Assert.Equal(2, serviceLayer.GetUpcomingBirthdays(new DateRange() { from = new DateTime(2023, 5, 15), to = new DateTime(2024, 5, 6) }).Count);
        }

        [Fact]
        public void ServiceLayer_GetUpcomingBirthdayDates()
        {
            Assert.Equal(new DateRange() { from = new DateTime(2023, 3, 10), to = new DateTime(2023, 3, 16) }, serviceLayer.GetUpcomingBirthdayDates(new DateTime(2023, 3, 1)));
            Assert.Equal(new DateRange() { from = new DateTime(2023, 12, 17), to = new DateTime(2024, 1, 6) }, serviceLayer.GetUpcomingBirthdayDates(new DateTime(2023, 12, 8)));
            Assert.Equal(new DateRange() { from = new DateTime(2023, 12, 23), to = new DateTime(2024, 1, 12) }, serviceLayer.GetUpcomingBirthdayDates(new DateTime(2023, 12, 14)));
            Assert.Equal(new DateRange() { from = new DateTime(2024, 1, 7), to = new DateTime(2024, 1, 13) }, serviceLayer.GetUpcomingBirthdayDates(new DateTime(2023, 12, 15)));
            Assert.Equal(new DateRange() { from = new DateTime(2024, 1, 17), to = new DateTime(2024, 1, 23) }, serviceLayer.GetUpcomingBirthdayDates(new DateTime(2023, 12, 25)));
        }

        [Fact]
        public void ServiceLayer_UpdateInOuts()
        {
            Listener l1 = serviceLayer.GetListenerById(1);
            l1.InOutRecords.In8 = 1;
            l1.InOutRecords.In4 = 1;
            l1.InOutRecords.Out5 = 1;
            //repoLayer.UpdateListener(serviceLayer.GetConnection(), l1);

            // Refresh
            l1 = serviceLayer.GetListenerById(1);

            Assert.Equal(1, l1.InOutRecords.In8);
            Assert.Equal(0, l1.InOutRecords.In7);
            Assert.Equal(0, l1.InOutRecords.In6);
            Assert.Equal(0, l1.InOutRecords.In5);
            Assert.Equal(1, l1.InOutRecords.In4);
            Assert.Equal(0, l1.InOutRecords.In3);
            Assert.Equal(0, l1.InOutRecords.In2);
            Assert.Equal(0, l1.InOutRecords.In1);
            Assert.Equal(0, l1.InOutRecords.Out8);
            Assert.Equal(0, l1.InOutRecords.Out7);
            Assert.Equal(0, l1.InOutRecords.Out6);
            Assert.Equal(1, l1.InOutRecords.Out5);
            Assert.Equal(0, l1.InOutRecords.Out4);
            Assert.Equal(0, l1.InOutRecords.Out3);
            Assert.Equal(0, l1.InOutRecords.Out2);
            Assert.Equal(0, l1.InOutRecords.Out1);

            serviceLayer.UpdateListenerInOuts();

            // Refresh
            l1 = serviceLayer.GetListenerById(1);

            Assert.Equal(0, l1.InOutRecords.In8);
            Assert.Equal(1, l1.InOutRecords.In7);
            Assert.Equal(0, l1.InOutRecords.In6);
            Assert.Equal(0, l1.InOutRecords.In5);
            Assert.Equal(0, l1.InOutRecords.In4);
            Assert.Equal(1, l1.InOutRecords.In3);
            Assert.Equal(0, l1.InOutRecords.In2);
            Assert.Equal(0, l1.InOutRecords.In1);
            Assert.Equal(1, l1.InOutRecords.Out8); // Will be 1 as they are an active listener
            Assert.Equal(0, l1.InOutRecords.Out7);
            Assert.Equal(0, l1.InOutRecords.Out6);
            Assert.Equal(0, l1.InOutRecords.Out5);
            Assert.Equal(1, l1.InOutRecords.Out4);
            Assert.Equal(0, l1.InOutRecords.Out3);
            Assert.Equal(0, l1.InOutRecords.Out2);
            Assert.Equal(0, l1.InOutRecords.Out1);
        }

        [Fact]
        public void ServiceLayer_CollectorForListener()
        {
            Listener l1 = serviceLayer.GetListenerById(1);
            Listener l2 = serviceLayer.GetListenerById(2);
            Listener l3 = serviceLayer.GetListenerById(3);
            Collector c1 = serviceLayer.GetCollectorForListener(l1);
            Assert.Equal("Ted", c1.Forename);
            Collector c2 = serviceLayer.GetCollectorForListener(l2);
            Assert.Equal("Unknown", c2.Forename);
            Collector c3 = serviceLayer.GetCollectorForListener(l3);
            Assert.Equal("Ted", c3.Forename);

            Listener l4 = new Listener()
            {
                Title = "Miss",
                Forename = "Clean",
                Surname = "Dates",
                Addr1 = "40 Clean Road",
                Addr2 = "",
                County = "London",
                Postcode = "N192DB",
                Town = "Camden",
                Telephone = "07843434343",
                Stock = 3,
                Info = "",
                Joined = DateTime.Now,
                MemStickPlayer = false,
                Magazine = true,
                Status = ListenerStates.ACTIVE,
                StatusInfo = "",
                Wallet = 55,
                DeletedDate = DateTime.ParseExact("01/01/1000", DateHelpers.DEFAULT_DATE_FORMAT, null),
                LastIn = DateTime.ParseExact("01/01/1000", DateHelpers.DEFAULT_DATE_FORMAT, null),
                LastOut = DateTime.ParseExact("01/01/1000", DateHelpers.DEFAULT_DATE_FORMAT, null)
            };
            Collector c4 = serviceLayer.GetCollectorForListener(l4);
            Assert.Equal("Unknown", c4.Forename);
        }

        [Fact]
        public void ServiceLayer_GetWeeklyStatsForNewWeek()
        {
            WeeklyStats stats = serviceLayer.GetCurrentWeekStats();

            Assert.NotNull(stats);
        }

        [Fact]
        public void ServiceLayer_GetWeeklyStatsForWeek()
        {
            WeeklyStats stats = serviceLayer.GetCurrentWeekStats();

            Assert.NotNull(stats);
            Assert.Equal(20, stats.ScannedIn);
            Assert.Equal(14, stats.ScannedOut);
            Assert.Equal(17, stats.TotalListeners);
            Assert.Equal(3, stats.PausedCount);
            Assert.Equal(5, stats.WeekNumber);
        }
    }
}
