using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TNBase.Objects;

namespace TNBase.Forms.Scanning
{
    public partial class ScanOutForm : Form
    {
        private List<Scan> scans = new List<Scan>();
        private List<int> walletsToScan;
        private WalletTypes walletType;

        public IEnumerable<Scan> Scans => scans;

        public ScanOutForm()
        {
            InitializeComponent();
        }

        private void txtScannerInput_TextChanged(object sender, EventArgs e)
        {
            if (txtScannerInput.Text.Length > 5)
            {
                Scan();
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
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
                if (walletsToScan.Contains(wallet))
                {
                    walletsToScan.Remove(wallet);
                    scans.Add(new Scan
                    {
                        Wallet = wallet,
                        ScanType = ScanTypes.OUT,
                        WalletType = walletType
                    });
                    ModuleSounds.PlayBeep();
                    lblStatus.Text = $"Last scanned {wallet}.";
                    UpdateScanList(wallet);
                }
                else
                {
                    if (scans.Any(x => x.Wallet == wallet))
                    {
                        ModuleSounds.PlaySecondBeep();
                        lblStatus.Text = $"Duplicate! Wallet {wallet} already scanned.";
                    }
                    else
                    {
                        ModuleSounds.PlayExplode();
                        lblStatus.Text = $"Not Found! Wallet {wallet} should not be scanned.";
                    }
                }
            }
            else
            {
                ModuleSounds.PlayInvalidBarcode();
                lblStatus.Text = $"Invalid barcode {txtScannerInput.Text}.";
            }

            txtScannerInput.Text = "";
        }

        private void UpdateScanList(int lastScaned)
        {
            lstToScan.Items.Clear();
            lstToScan.Items.AddRange(walletsToScan
                .OrderBy(x => x)
                .Select(x => new ListViewItem(x.ToString()))
                .ToArray());

            lstScanned.Items.Clear();
            lstScanned.Items.AddRange(scans
                .Select(x => new ListViewItem(x.Wallet.ToString())
                {
                    Selected = lastScaned == x.Wallet
                })
                .ToArray());
        }

        private void FormMagazineScanIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK && scans.Any())
            {
                var result = MessageBox.Show("Closing this form will discard all the scans. Do you want to continue?", "Close", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        public void Setup(string title, WalletTypes walletType, IEnumerable<int> walletsToScan, IEnumerable<int> scanned = null)
        {
            this.walletType = walletType;
            this.walletsToScan = walletsToScan.ToList();

            Text = title;
            ScanInputLabel.Text = $"Please scan in a {walletType.ToString().ToLower()} wallet:";

            if (scanned != null && scanned.Any())
            {
                scans.AddRange(scanned.Select(x => new Scan
                {
                    Wallet = x,
                    ScanType = ScanTypes.OUT,
                    WalletType = walletType
                }));
            }
        }

        private void ScanOutForm_Load(object sender, EventArgs e)
        {
            UpdateScanList(0);
        }
    }
}
