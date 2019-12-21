using System;

namespace TNBase.Objects
{
    /// <summary>
    /// Scan - some scan record
    /// </summary>
    public class Scan
    {

        /// <summary>
        /// The wallet number for the Listener
        /// </summary>
        public int Wallet;

        /// <summary>
        /// The scan type
        /// </summary>
        public ScanTypes scanType;

        /// <summary>
        /// The date the scan was made
        /// </summary>
        public DateTime recorded;

        public Scan()
        {
            this.recorded = DateTime.Now;
        }
    }
}
