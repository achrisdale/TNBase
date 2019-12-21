using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
namespace TNBase
{
    public partial class FormScannedOutTotal
    {
        private FormScanOut formScanOut;
        private FormMain formMain;

        public void setup(int totalScanned, FormScanOut formScanOut, FormMain formMain)
        {
            lblTotal.Text = totalScanned.ToString();
            this.formScanOut = formScanOut;
            this.formMain = formMain;
        }

        private void btnScanMore_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            this.Close();
            formScanOut.doClose();

            // Show birthdays form.
            new FormPrintBirthdays().Show();
            // Show not sent out form.
            new FormPrintNotSentWallets().Show();
        }

        private void formScannedOutTotal_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMain.ScanOutDone();
        }
        public FormScannedOutTotal()
        {
            FormClosed += formScannedOutTotal_FormClosed;
            InitializeComponent();
        }
    }
}
