﻿using System;
using System.Globalization;
using System.Linq;
using TNBase.Domain;
using TNBase.Repository;

namespace TNBase.App.Test
{
    public class DataSweeperBuilder
    {
        private readonly DataSweeperOptions options;
        private DateTime testDateTime;

        public DataSweeperBuilder()
        {
            options = new DataSweeperOptions();

            var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            Context = context;
        }

        public ITNBaseContext Context { get; internal set; }

        public DataSweeper Build()
        {
            var timeProvider = Substitute.For<ITimeProvider>();
            timeProvider.UtcNow.Returns(testDateTime);
            return new DataSweeper(Context, options, timeProvider);
        }

        public DataSweeperBuilder WithTestDate(string dateTime)
        {
            testDateTime = DateTime.ParseExact(dateTime, DateTimeExtensions.DEFAULT_FORMAT, CultureInfo.InvariantCulture);
            return this;
        }

        public DataSweeperBuilder WithDaysBeforePurgeReservedWallets(int days)
        {
            options.DaysBeforePurgeReservedWallets = days;
            return this;
        }

        public DataSweeperBuilder WithListenerReservedOn(string dateTime)
        {
            var listener = GetListener();
            listener.Status = ListenerStates.RESERVED;
            listener.ReservedDate = DateTime.ParseExact(dateTime, DateTimeExtensions.DEFAULT_FORMAT, CultureInfo.InvariantCulture);

            Context.Listeners.Add(listener);
            Context.SaveChanges();

            return this;
        }

        public DataSweeperBuilder WithListener(ListenerStates state, string deletedOn = null)
        {
            var listener = GetListener();
            listener.Status = state;
            listener.DeletedDate = deletedOn != null ? DateTime.ParseExact(deletedOn, DateTimeExtensions.DEFAULT_FORMAT, CultureInfo.InvariantCulture) : null;

            Context.Listeners.Add(listener);
            Context.SaveChanges();

            return this;
        }

        private Listener GetListener()
        {
            var count = Context.Listeners.Count();
            return new Listener
            {
                Wallet = count + 1,
                Status = ListenerStates.ACTIVE,
                Title = "Mr",
                Forename = "John",
                Surname = "Biddle",
                Addr1 = "1 Park Avenue",
                Addr2 = "",
                County = "London",
                Postcode = "N7 NDF",
                Town = "Camden",
                Telephone = "01234 423 232",
                Stock = 3,
                Info = "",
                Joined = DateTime.Now,
                MemStickPlayer = false,
                Magazine = true,
                StatusInfo = "",
                LastOut = DateTime.Now.AddMonths(-2),
                InOutRecords = new InOutRecords(),
                BirthdayDay = 1,
                BirthdayMonth = 4
            };
        }
    }
}