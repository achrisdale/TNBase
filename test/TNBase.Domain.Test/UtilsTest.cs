using System;
using Xunit;

namespace TNBase.Domain.Test
{
    public class UtilsTest
    {
        [Fact]
        public void ValidPostcode_NoSurnameSpec()
        {
            Utils.validatePostcode("CF14");
        }

        [Fact]
        public void ValidPostcode_SurnameSpec()
        {
            Utils.validatePostcode("CF145DD [A-H]");
        }

        [Fact]
        public void InvalidPostcode()
        {
            Assert.Throws<FormatException>(() =>
                Utils.validatePostcode("CF4344!")
            );
        }

        [Fact]
        public void InvalidPostcode_TooLong()
        {
            Assert.Throws<FormatException>(() =>
                Utils.validatePostcode("CF4344d3")
            );
        }

        [Fact]
        public void PostcodeValidForSurname()
        {
            Assert.True(Utils.postcodeValidForSurname("CF14 [A-F]", "Francis"));
            Assert.False(Utils.postcodeValidForSurname("CF14 [A-F]", "Zoric"));
            Assert.True(Utils.postcodeValidForSurname("CJ24 4D [J-Z]", "Zoric"));
            Assert.True(Utils.postcodeValidForSurname("CJ24 4D", "Zoric"));
        }

        [Fact]
        public void RemoveSurnameSpec_Multiple()
        {
            Assert.Equal("CF146DD", Utils.removeSurnameSpecifier("CF14 6DD [A-H]"));
            Assert.Equal("CF1", Utils.removeSurnameSpecifier("CF1 [A-H]"));
            Assert.Equal("CF1CH", Utils.removeSurnameSpecifier("Cf1ch [A-H]"));
        }
    }
}
