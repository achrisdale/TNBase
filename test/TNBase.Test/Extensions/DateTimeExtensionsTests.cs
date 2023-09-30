using System;
using TNBase.Infrastructure.Extensions;
using Xunit;

namespace TNBase.Test.Extensions
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void WeekOfYear_ShouldGetWeekNumber()
        {
            var date = new DateTime(2014, 1, 1);
            var weekNumber = date.WeekOfYear();
            Assert.Equal(1, weekNumber);
        }

        [Fact]
        public void WeekOfYear_ShouldGetCorrectIso8601WeekNumberForLeapYear()
        {
            var date = new DateTime(2013, 12, 31);
            var weekNumber = date.WeekOfYear();
            Assert.Equal(1, weekNumber);
        }

        [Fact]
        public void WeekStart_ShouldGetMondayZeroHours_WhenMonday()
        {
            var date = new DateTime(2020, 1, 13, 10, 15, 30);
            var weekStart = date.WeekStart();
            Assert.Equal(new DateTime(2020, 1, 13, 0, 0, 0), weekStart);
        }

        [Fact]
        public void WeekStart_ShouldGetMondayZeroHours_WhenSunday()
        {
            var date = new DateTime(2020, 1, 19, 10, 15, 30);
            var weekStart = date.WeekStart();
            Assert.Equal(new DateTime(2020, 1, 13, 0, 0, 0), weekStart);
        }

        [Fact]
        public void NextWeekStart_ShouldGetNextWeeksMondayZeroHours_WhenMonday()
        {
            var date = new DateTime(2020, 1, 13, 10, 15, 30);
            var nextWeekStart = date.NextWeekStart();
            Assert.Equal(new DateTime(2020, 1, 20, 0, 0, 0), nextWeekStart);
        }

        [Fact]
        public void NextWeekStart_ShouldGetNextWeeksMondayZeroHours_WhenSunday()
        {
            var date = new DateTime(2020, 1, 19, 10, 15, 30);
            var nextWeekStart = date.NextWeekStart();
            Assert.Equal(new DateTime(2020, 1, 20, 0, 0, 0), nextWeekStart);
        }
    }
}
