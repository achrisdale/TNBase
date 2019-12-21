using System;
using System.Windows.Forms;
namespace TNBase
{
    public partial class FormScannedInTotal
    {
        private FormScanIn formScanIn;
        private FormMain formMain;

        public void setup(int totalScanned, FormScanIn formScanIn, FormMain formMain)
        {
            lblTotal.Text = totalScanned.ToString();
            this.formScanIn = formScanIn;
            this.formMain = formMain;
        }

        private void btnScanMore_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            this.Close();
            formScanIn.doClose();
        }

        private void formScannedInTotal_FormClosing(object sender, FormClosingEventArgs e)
        {
            formMain.ScanInDone();
        }
        public FormScannedInTotal()
        {
            FormClosing += formScannedInTotal_FormClosing;
            InitializeComponent();
        }
    }
}
