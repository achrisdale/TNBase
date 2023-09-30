using TNBase.App;
using TNBase.Domain;
using System.Collections.Generic;
using Xunit;
using NSubstitute;

namespace TNBase.Test
{
    public class GenericTester
    {
        [Fact]
        public void Generic_BasicTimeTest()
        {
            ModuleGeneric.SaveStartTime();
            ModuleGeneric.saveEndTime();
            ModuleGeneric.getStartTimeString();
            ModuleGeneric.getEndTimeString();
            Assert.Equal("00:00:00", ModuleGeneric.getElapsedTimeString());
        }

        /// <summary>
        /// Base for the weekly stat test methods
        /// </summary>
        /// <param name="newStatsWeek">Is it a new stats week?</param>
        /// <param name="expectingInOuts">Should the in out bits be updated?</param>
        private void WeekStatTest_Base(bool newStatsWeek)
        {
            var serviceLayer = Substitute.For<IServiceLayer>();
            serviceLayer.GetCurrentWeekNumber().Returns(100);
            serviceLayer.GetCurrentListenerCount().Returns(10);
            serviceLayer.GetListenersByStatus(Arg.Any<ListenerStates>()).Returns(new List<Listener>() { });
            serviceLayer.WeeklyStatExistsForWeek(100).Returns(newStatsWeek);
            serviceLayer.GetCurrentWeekStats().Returns(new WeeklyStats { WeekNumber = 100 });

            ModuleGeneric.UpdateStatsWeek(serviceLayer);

            // Check we add/update the week stats
            if (newStatsWeek)
            {
                serviceLayer.Received(1).UpdateWeeklyStats(Arg.Is<WeeklyStats>(y => y.TotalListeners == 10 && y.WeekNumber == 100 && y.PausedCount == 0));
            }
            else
            {
                serviceLayer.Received(1).SaveWeekStats(Arg.Is<WeeklyStats>(y => y.TotalListeners == 10 && y.WeekNumber == 100 && y.PausedCount == 0));
            }
        }

        [Fact]
        public void Generic_WeekStatSave_SaveWeekStats()
        {
            WeekStatTest_Base(false);
        }

        [Fact]
        public void Generic_WeekStatSave_UpdateWeeklyStats()
        {
            WeekStatTest_Base(true);
        }
    }
}
