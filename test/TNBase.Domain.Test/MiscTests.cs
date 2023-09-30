using System;
using Xunit;

namespace TNBase.Domain.Test
{
    public class MiscTests
    {
        [Fact]
        public void DateTime_Sat_Test()
        {
            DateTime dt = DateTime.ParseExact("28/01/2017", "dd/MM/yyyy", null);
            Assert.Equal(DayOfWeek.Saturday, dt.DayOfWeek);
        }
    }
}
