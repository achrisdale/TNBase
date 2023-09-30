using System;
using TNBase.Infrastructure.Helpers;
using Xunit;

namespace TNBase.App.Test
{
    public class ExtensionTests
    {
        [Fact]
        public void Extensions_EnsureMinDate()
        {
            DateTime original = DateTime.ParseExact("01/01/1888", DateHelpers.DEFAULT_DATE_FORMAT, null);
            DateTime second = original.EnsureMinDate();

            Assert.True(second > original, "Expected the date to be uplifted");
        }
    }
}
