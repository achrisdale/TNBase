using System;

namespace TNBase.Objects
{
    public class Scan
    {
        public int Wallet { get; set; }
        public ScanTypes ScanType { get; set; }
        public DateTime Recorded { get; set; }
        public WalletTypes WalletType { get; set; }
    }
}
