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
using TNBase.Objects;
using NLog;
using TNBase.DataStorage;

namespace TNBase
{
    public partial class FormAddFull
    {
        // Logging instance.
        private Logger log = LogManager.GetCurrentClassLogger();

        IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Confirm we really want to cancel.
            DialogResult result = MessageBox.Show("Are you sure you wish to cancel?" + Environment.NewLine + Environment.NewLine + "Press [y] to confirm, [n] to cancel.", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow digits.
            if (!char.IsDigit(e.KeyChar) & !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Add the listener to the database.
        private void btnFinished_Click(object sender, EventArgs e)
        {
            Listener newListener = new Listener();
            newListener.Wallet = 0;
            newListener.Title = comboTitle.Text;
            newListener.Forename = txtForename.Text;
            newListener.Surname = txtSurname.Text;
            newListener.Addr1 = txtAddr1.Text;
            newListener.Addr2 = txtAddr2.Text;
            newListener.Town = txtTown.Text;
            newListener.County = txtCounty.Text;
            newListener.Postcode = txtPostcode.Text;
            newListener.MemStickPlayer = chkTape.Checked;
            newListener.Magazine = chkMagazine.Checked;
            newListener.Info = txtInformation.Text;
            if ((!string.IsNullOrEmpty(txtTelephone.Text)))
            {
                Wallet = 0,
                Title = comboTitle.Text,
                Forename = txtForename.Text,
                Surname = txtSurname.Text,
                Addr1 = txtAddr1.Text,
                Addr2 = txtAddr2.Text,
                Town = txtTown.Text,
                County = txtCounty.Text,
                Postcode = txtPostcode.Text,
                MemStickPlayer = chkTape.Checked,
                Magazine = chkMagazine.Checked,
                Info = txtInformation.Text,
                Telephone = string.IsNullOrEmpty(txtTelephone.Text) ? "0" : txtTelephone.Text,
                BirthdayDay = cbxBirthdayDay.SelectedIndex + 1,
                BirthdayMonth = cbxBirthdayMonth.SelectedIndex + 1,
                Status = ListenerStates.ACTIVE,
                StatusInfo = "",
                DeletedDate = DateTime.Now,
                Joined = DateTime.Now,
                inOutRecords = new InOutRecords()
            };

            var result = serviceLayer.AddListener(newListener);
            if (result > 0)
            {
                log.Debug("Listener has been added. ID: " + result + ", Name: " + newListener.GetNiceName());
                Interaction.MsgBox("The listener has successfully been added.");

                var newListenerWithWalletNo = serviceLayer.GetListenerById(result);

                PrintLabels(newListenerWithWalletNo);
                PrintMemoryStickForm(newListenerWithWalletNo);
            }
            else
            {
                newListener.Telephone = "0";
            }
            string theStr = "";
            if (chkNoBirthday.Checked)
            {
                theStr = "01/01/" + DateTime.Now.Year;
            }
        }

        private void PrintLabels(Listener listener)
        {
            var msgResult = MessageBox.Show("Would you like to print labels for the new listener?", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
            if (msgResult == DialogResult.Yes)
            {
                var form = new FormChoosePrintPoint();
                form.SetupForm(listener);
                form.ShowDialog();
            }
        }

        private DateTime? GetBirthdayValue()
        {
            if (chkNoBirthday.Checked)
            {
                return null;
            }

            var day = cbxBirthdayDay.SelectedIndex + 1;
            var month = cbxBirthdayMonth.SelectedIndex + 1;
            return new DateTime(DateTime.Now.Year, month, day);
        }

        public FormAddFull()
        {
            InitializeComponent();

                Listener newListenerWithWalletNo = serviceLayer.GetListenerById(result);

                // Do new labels need to be added?
                DialogResult msgResult = MessageBox.Show("Would you like to print labels for the new listener?", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
                if (msgResult == DialogResult.Yes)
                {
                    My.MyProject.Forms.formChoosePrintPoint.Show();
                    My.MyProject.Forms.formChoosePrintPoint.SetupForm(newListenerWithWalletNo);
                }

                // Will they use a memory stick player?
                if (newListener.MemStickPlayer)
                {
                    Interaction.MsgBox("Please print the following form as listener requires a memory stick player.");
                    My.MyProject.Forms.formPrintCollectionForm.Show();
                    My.MyProject.Forms.formPrintCollectionForm.setupForm(newListenerWithWalletNo, false);
                }

                this.Close();
            }
            else
            {
                log.Error("Failed to add new listener!");
                Interaction.MsgBox("Failed to add new listener!");
                this.Close();
            }
        }

        private void formAddFull_Load(object sender, EventArgs e)
        {
            comboTitle.Items.AddRange(ListenerTitles.getAllTitles().ToArray());
        }

        public FormAddFull()
        {
            Load += formAddFull_Load;
            InitializeComponent();

            // Restrict input to month and day
            birthdayDate.MinDate = new DateTime(DateTime.UtcNow.Year, 01, 01);
            birthdayDate.MaxDate = new DateTime(DateTime.UtcNow.Year, 12, 31);
            birthdayDate.Format = DateTimePickerFormat.Custom;
            birthdayDate.CustomFormat = "dd MMMM";
        }
    }
}
