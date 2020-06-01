using System;
using System.Windows.Forms;
using TNBase.DataStorage;
using TNBase.Objects;

namespace TNBase.Forms
{
    public partial class FormDelete : Form
    {
        private IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());
        private Listener listener;

        public FormDelete()
        {
            InitializeComponent();
        }

        public static FormDelete Create(Listener listener)
        {
            var form = new FormDelete { listener = listener };
            form.listenerDetailsLabel.Text = listener.FormatListenerData();
            form.memStickGroupBox.Visible = listener.MemStickPlayer;
            form.UpdateMemStickReceived(listener.MemStickPlayer);
            form.btnDelete.Enabled = true;
            return form;
        }

        private void UpdateMemStickReceived(bool memStickPlayer)
        {
            yesMemStickRadioButton.Checked = !memStickPlayer;
            noMemStickRadioButton.Checked = memStickPlayer;
            toolStripStatusLabel.Text = memStickPlayer ?
                "Listener's data will be deleted automatically once the memory stick is returned" :
                $"Listener has no memory stick, therefore it's data will be deleted and the wallet reserved for {Settings.Default.MonthsUntilDelete} months";
            btnDelete.Text = memStickPlayer ? "Mark for deletion" : "Permanently delete";
        }

        private void memStickRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMemStickReceived(noMemStickRadioButton.Checked);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listener.MemStickPlayer && yesMemStickRadioButton.Checked)
            {
                listener.MemStickPlayer = false;
            }

            listener.Delete();
            serviceLayer.UpdateListener(listener);

            if (listener.MemStickPlayer)
            {
                PrintMemStickCollectionForm();
            }
        }

        private void PrintMemStickCollectionForm()
        {
            var collectionForm = new FormPrintCollectionForm();
            collectionForm.SetupForm(listener, true);
        }
    }
}
