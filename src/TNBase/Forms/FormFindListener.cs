﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TNBase.App;
using TNBase.Domain;

namespace TNBase.Forms
{
    public partial class FormFindListener : Form
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

        private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();

        public FindListenerFormType theType;
        private void formFindListener_Load(object sender, EventArgs e)
        {
            theType = FindListenerFormType.EditForm;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var listeners = FindListeners();

            if (!listeners.Any())
            {
                Interaction.MsgBox("Could not find any listeners.");
                return;
            }

            if (listeners.Count() > 1)
            {
                ShowDuplicateForm(listeners);
                return;
            }

            var listener = listeners.First();

            if (theType == FindListenerFormType.DeleteForm)
            {
                var deleteForm = FormDelete.Create(listener);
                deleteForm.ShowDialog();
            }

            if (theType == FindListenerFormType.EditForm)
            {
                My.MyProject.Forms.formEdit.Show();
                My.MyProject.Forms.formEdit.Setup(listener);
            }

            if (theType == FindListenerFormType.StopSending)
            {
                My.MyProject.Forms.formStopSending.Show();
                My.MyProject.Forms.formStopSending.Setup(listener);
            }

            if (theType == FindListenerFormType.PrintLabels)
            {
                var form = new FormChoosePrintPoint();
                form.SetupForm(listener);
                form.ShowDialog();
            }

            if (theType == FindListenerFormType.AdjustStock)
            {
                FormAdjustStockLevels formAdjustStock = new FormAdjustStockLevels();
                formAdjustStock.setListener(listener);
                formAdjustStock.Show();
            }

            if (theType == FindListenerFormType.PrintCollector)
            {
                bool deleted = true;
                if (!listener.OnlineOnly)
                {
                    DialogResult result = MessageBox.Show("Are you printing this form for a deleted listener? (Select No if its a new one)", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
                    deleted = result == DialogResult.Yes;
                }

                My.MyProject.Forms.formPrintCollectionForm.Show();
                My.MyProject.Forms.formPrintCollectionForm.SetupForm(listener, deleted);
            }

            Close();
        }

        private void ShowDuplicateForm(IEnumerable<Listener> listeners)
        {
            My.MyProject.Forms.formDuplicates.Show();
            if (theType == FindListenerFormType.DeleteForm)
            {
                My.MyProject.Forms.formDuplicates.setupForm(FormDuplicates.DuplicateFormType.DeleteForm);
            }
            if (theType == FindListenerFormType.EditForm)
            {
                My.MyProject.Forms.formDuplicates.setupForm(FormDuplicates.DuplicateFormType.EditForm);
            }
            if (theType == FindListenerFormType.StopSending)
            {
                My.MyProject.Forms.formDuplicates.setupForm(FormDuplicates.DuplicateFormType.StopSending);
            }
            if (theType == FindListenerFormType.PrintLabels)
            {
                My.MyProject.Forms.formDuplicates.setupForm(FormDuplicates.DuplicateFormType.PrintLabels);
            }
            if (theType == FindListenerFormType.PrintCollector)
            {
                My.MyProject.Forms.formDuplicates.setupForm(FormDuplicates.DuplicateFormType.PrintCollector);
            }
            if (theType == FindListenerFormType.AdjustStock)
            {
                My.MyProject.Forms.formDuplicates.setupForm(FormDuplicates.DuplicateFormType.AdjustStock);
            }
            foreach (Listener listener in listeners)
            {
                My.MyProject.Forms.formDuplicates.addDuplicate(listener);
            }
            Close();
        }

        private IEnumerable<Listener> FindListeners()
        {
            var listeners = new List<Listener>();
            if (!string.IsNullOrEmpty(txtWallet.Text))
            {
                var wallet = int.Parse(txtWallet.Text);
                var listener = serviceLayer.GetListenerById(wallet);
                if (listener != null)
                {
                    listeners.Add(listener);
                }
            }
            else if (!string.IsNullOrEmpty(txtForename.Text) || !string.IsNullOrEmpty(txtSurname.Text))
            {
                listeners.AddRange(serviceLayer.GetListenersByName(txtForename.Text, txtSurname.Text));
            }

            return listeners.Where(x => x.Status == ListenerStates.ACTIVE || x.Status == ListenerStates.PAUSED).ToList();
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
