using System;
using Xunit;

namespace TNBase.Domain.Test
{
    public class DateTimeExtensionTester
    {
        [Fact]
        public void NullableDateTimeTests()
        {
            Nullable<DateTime> dateTime = null;
            Assert.Equal("N/a", dateTime.ToNullableNaString());

            dateTime = new DateTime(1999, 1, 2);
            Assert.Equal("02/01/1999", dateTime.ToNullableNaString());
        } 
    }
}
