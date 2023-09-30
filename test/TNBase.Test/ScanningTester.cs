using TNBase.Infrastructure;
using Xunit;

namespace TNBase.Test
{
    public class ScanningTester
    {
        [Fact]
        public void Scanning_ScanInOutTest()
        {
            // Simple test.
            ModuleScanning.setScannedIn(100);
            ModuleScanning.setScannedOut(100);

            Assert.True(ModuleScanning.getScannedIn() == 100 && ModuleScanning.getScannedOut() == 100);
        }

        [Fact]
        public void Scanning_ScanInOutBelowZero()
        {
            // Test negatives are handled.
            ModuleScanning.setScannedIn(-2);
            ModuleScanning.setScannedOut(-400);

            Assert.True(ModuleScanning.getScannedIn() == 0 && ModuleScanning.getScannedOut() == 0);
        }
    }
}
