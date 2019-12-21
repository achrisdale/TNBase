using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TNBase.DataStorage;
using TNBase.Forms;
using TNBase.Objects;

namespace TNBase
{
    public partial class FormFindListener
    {
        public enum FindListenerFormType
        {
            DeleteForm,
            EditForm,
            StopSending,
            PrintLabels,
            PrintCollector,
            AdjustStock
        }

        private IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

        public FindListenerFormType theType;
        private void formFindListener_Load(object sender, EventArgs e)
        {
            theType = FindListenerFormType.EditForm;
        }

        private void deleteListenerLocal(int walletNumber)
        {
            string dataString = null;
            dataString = Listener.FormatListenerData(serviceLayer.GetListenerById(walletNumber));

            // Show prompt.
            DialogResult result = MessageBox.Show("Are you sure you wish to delete the following listener?" + Environment.NewLine + Environment.NewLine + dataString + Environment.NewLine + "Press [Y] to confirm or [N] to cancel.", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else if (result == DialogResult.Yes)
            {
                string myReason = new FormInput().ShowDialog("Please enter a reason for deletion", "S.B.T.N.A.", "");
                bool resultofdelete = false;

                // Check if the delete was a success.
                resultofdelete = serviceLayer.SoftDeleteListener(serviceLayer.GetListenerById(walletNumber), myReason);
                if (resultofdelete)
                {
                    MessageBox.Show("Listener deleted successfully.", ModuleGeneric.getAppShortName());
                    MessageBox.Show("You should remove all wallets including the magazine wallet" + Environment.NewLine + "from stock for Wallet number " + txtWallet.Text + ".", ModuleGeneric.getAppShortName(), MessageBoxButtons.OK);

                    // Check if the player / memory stick has been returned.
                    var tempListener = serviceLayer.GetListenerById(walletNumber);
                    if ((tempListener.MemStickPlayer))
                    {
                        DialogResult walletReturned = MessageBox.Show("Did the listener return the memory stick player?", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
                        if (walletReturned == DialogResult.Yes)
                        {
                            tempListener.MemStickPlayer = false;
                            if (!serviceLayer.UpdateListener(tempListener))
                            {
                                MessageBox.Show("Error deleting listener.", ModuleGeneric.getAppShortName());
                            }
                        }
                        else
                        {
                            // Else print deleted listener form.
                            var form = new FormPrintCollectionForm();
                            form.Show();
                            form.setupForm(tempListener, true);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error deleting listener.", ModuleGeneric.getAppShortName());
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Search for the wallet id.
            if (!string.IsNullOrEmpty(txtWallet.Text))
            {

                if ((serviceLayer.GetListenerById(int.Parse(txtWallet.Text)) != null))
                {
                    // Are we in delete mode?
                    if (theType == FindListenerFormType.DeleteForm)
                    {
                        deleteListenerLocal(int.Parse(txtWallet.Text));
                        this.Close();
                    }

                    // Are we in delete mode?
                    if (theType == FindListenerFormType.EditForm)
                    {
                        var form = new FormEdit();
                        form.Show();
                        form.setupForm(serviceLayer.GetListenerById(int.Parse(txtWallet.Text)));
                        this.Close();
                    }

                    if (theType == FindListenerFormType.StopSending)
                    {
                        var form = new FormStopSending();
                        form.Show();
                        form.setupForm(serviceLayer.GetListenerById(int.Parse(txtWallet.Text)));
                        this.Close();
                    }

                    if (theType == FindListenerFormType.PrintLabels)
                    {
                        var form = new FormChoosePrintPoint();
                        form.Show();
                        form.SetupForm(serviceLayer.GetListenerById(int.Parse(txtWallet.Text)));
                        this.Close();
                    }

                    if (theType == FindListenerFormType.AdjustStock)
                    {
                        FormAdjustStockLevels formAdjustStock = new FormAdjustStockLevels();
                        formAdjustStock.setListener(serviceLayer.GetListenerById(int.Parse(txtWallet.Text)));
                        formAdjustStock.Show();
                        this.Close();
                    }

                    if (theType == FindListenerFormType.PrintCollector)
                    {
                        DialogResult result = MessageBox.Show("Are you printing this form for a deleted listener? (Select No if its a new one)", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
                        bool deleted = (result == DialogResult.Yes);

                        var form = new FormPrintCollectionForm();
                        form.Show();
                        form.setupForm(serviceLayer.GetListenerById(int.Parse(txtWallet.Text)), deleted);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Could not find a listener with the following Wallet number: " + txtWallet.Text, ModuleGeneric.getAppShortName());
                }
            }

            // Search for the name / surname.
            if (!(string.IsNullOrEmpty(txtForename.Text) & string.IsNullOrEmpty(txtSurname.Text)))
            {
                List<Listener> theListeners = new List<Listener>();
                theListeners = serviceLayer.GetListenersByName(txtForename.Text, txtSurname.Text);

                if ((theListeners.Count > 0))
                {
                    // If there is just one duplicate.
                    if (theListeners.Count == 1)
                    {
                        // Look up data.
                        Listener theListener = theListeners[0];

                        // Delete form.
                        if (theType == FindListenerFormType.DeleteForm)
                        {
                            string dataString = null;
                            dataString = Listener.FormatListenerData(theListener);
                            deleteListenerLocal(theListener.Wallet);
                            this.Close();
                        }

                        // Edit form.
                        if (theType == FindListenerFormType.EditForm)
                        {
                            var form = new FormEdit();
                            form.Show();
                            form.setupForm(theListener);
                            this.Close();
                        }
                        if (theType == FindListenerFormType.StopSending)
                        {
                            var form = new FormStopSending();
                            form.Show();
                            form.setupForm(theListener);
                            this.Close();
                        }
                        if (theType == FindListenerFormType.PrintLabels)
                        {
                            var form = new FormChoosePrintPoint();
                            form.Show();
                            form.SetupForm(theListener);
                            this.Close();
                        }
                        if (theType == FindListenerFormType.AdjustStock)
                        {
                            FormAdjustStockLevels formAdjustStock = new FormAdjustStockLevels();
                            formAdjustStock.setListener(serviceLayer.GetListenerById(int.Parse(txtWallet.Text)));
                            formAdjustStock.Show();
                            this.Close();
                        }
                        if (theType == FindListenerFormType.PrintCollector)
                        {
                            DialogResult result = MessageBox.Show("Are you printing this form for a deleted listener? (Select No if its a new one)", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
                            bool deleted = (result == DialogResult.Yes);

                            var form = new FormPrintCollectionForm();
                            form.Show();
                            form.setupForm(theListener, deleted);
                            this.Close();
                        }
                    }
                    else
                    {
                        // If there are more than 1 duplicate.
                        var form = new FormDuplicates();
                        form.Show();
                        if (theType == FindListenerFormType.DeleteForm)
                        {
                            form.setupForm(FormDuplicates.DuplicateFormType.DeleteForm);
                        }
                        if (theType == FindListenerFormType.EditForm)
                        {
                            form.setupForm(FormDuplicates.DuplicateFormType.EditForm);
                        }
                        if (theType == FindListenerFormType.StopSending)
                        {
                            form.setupForm(FormDuplicates.DuplicateFormType.StopSending);
                        }
                        if (theType == FindListenerFormType.PrintLabels)
                        {
                            form.setupForm(FormDuplicates.DuplicateFormType.PrintLabels);
                        }
                        if (theType == FindListenerFormType.PrintCollector)
                        {
                            form.setupForm(FormDuplicates.DuplicateFormType.PrintCollector);
                        }
                        if (theType == FindListenerFormType.AdjustStock)
                        {
                            form.setupForm(FormDuplicates.DuplicateFormType.AdjustStock);
                        }
                        foreach (Listener tListener in theListeners)
                        {
                            form.addDuplicate(tListener);
                        }
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Could not find any listeners with the Forename and Surname provided.", ModuleGeneric.getAppShortName());
                }
            }
        }

        private void txtWallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow digits.
            if (!char.IsDigit(e.KeyChar) & !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public FormFindListener()
        {
            Load += formFindListener_Load;
            InitializeComponent();
        }
    }
}
