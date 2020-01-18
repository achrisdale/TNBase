using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TNBase.DataStorage;
using TNBase.Objects;

namespace TNBase.Forms.Scanning
{
    public partial class FormMagazineScanIn : Form
    {
        private List<Scan> scans = new List<Scan>();
        private int LastScan;

        public FormMagazineScanIn()
        {
            InitializeComponent();
        }

        private void FormMagazineScanIn_Load(object sender, EventArgs e)
        {

        }

        private void txtScannerInput_TextChanged(object sender, EventArgs e)
        {
            if (txtScannerInput.Text.Length > 5)
            {
                Scan();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string result = Interaction.InputBox("Scan bascode to remove from the list", "Remove Scan");
            if (!string.IsNullOrWhiteSpace(result))
            {
                int.TryParse(result, out int wallet);
                var scan = scans.LastOrDefault(x => x.Wallet == wallet);
                if (scan != null)
                {
                    scans.Remove(scan);
                    UpdateScanList(wallet);
                }
            }
        }

        private void btnScanOut_Click(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

        }

        private void txtScannerInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (!string.IsNullOrWhiteSpace(txtScannerInput.Text))
                    Scan();
            }
        }

        private void Scan()
        {
            int.TryParse(txtScannerInput.Text, out int wallet);
            if (wallet > 0)
            {
                scans.Add(new Scan
                {
                    Wallet = wallet,
                    ScanType = ScanTypes.IN,
                    WalletType = WalletTypes.Magazine
                });

                var count = scans.Count(x => x.Wallet == wallet);
                if (count > 1)
                    ModuleSounds.PlayBeep();
                else
                    ModuleSounds.PlaySecondBeep();

                UpdateScanList(wallet);
            }
            else
            {
                ModuleSounds.PlayInvalidBarcode();
            }

            txtScannerInput.Text = "";
        }

        private void UpdateScanList(int lastScaned)
        {
            lstScanned.Items.Clear();
            lstScanned.Items.AddRange(scans
                .GroupBy(x => x.Wallet)
                .Select(x => new ListViewItem(new string[] { x.First().Wallet.ToString(), x.Count().ToString() })
                {
                    Selected = lastScaned == x.First().Wallet
                })
                .ToArray());
        }
    }
}
