using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using TNBase.Objects;
using TNBase.DataStorage;
using TNBase.Forms;
using NLog;

namespace TNBase
{
    public partial class FormBrowse
    {
        private Logger log = LogManager.GetCurrentClassLogger();
        private IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

        private List<Listener> listeners = new List<Listener>();
        private Listener selectedListener;
        int pageSize = 15;
        int page = 0;
        private bool showDeleted = false;

        private void btnDone_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void UpdateOrder()
        {
            if (string.IsNullOrEmpty(cmbOrder.Text))
            {
                cmbOrder.Text = cmbOrder.Items[0].ToString();
            }
        }

        public void AddToListeners(Listener listener)
        {
            try
            {
                lstFreeze.Items.Add(listener.Wallet.ToString());

                var subItems = new List<string>
                {
                    listener.Title,
                    listener.Forename,
                    listener.Surname,
                    listener.Addr1,
                    listener.Addr2,
                    listener.Town,
                    listener.County,
                    listener.Postcode,
                    listener.Magazine.ToString(),
                    listener.MemStickPlayer.ToString(),
                    listener.Telephone,
                    listener.Joined.ToNullableNaString(DateTimeExtensions.DEFAULT_FORMAT),
                    listener.Birthday.ToNullableNaString(DateTimeExtensions.BIRTHDAY_FORMAT),
                    listener.Status.ToString(),
                    listener.StatusInfo,
                    listener.Stock.ToString(),
                    listener.MagazineStock.ToString(),
                    listener.LastIn.ToNullableNaString(),
                    listener.LastOut.ToNullableNaString(),
                    listener.Info,
                    listener.inOutRecords.In1.ToString(),
                    listener.inOutRecords.In2.ToString(),
                    listener.inOutRecords.In3.ToString(),
                    listener.inOutRecords.In4.ToString(),
                    listener.inOutRecords.Out1.ToString(),
                    listener.inOutRecords.Out2.ToString(),
                    listener.inOutRecords.Out3.ToString(),
                    listener.inOutRecords.Out4.ToString()
                };

                var itm = new ListViewItem(subItems.ToArray());
                if (listener.Status == ListenerStates.DELETED)
                {
                    itm.BackColor = Color.DarkRed;
                    itm.ForeColor = Color.White;
                }
                else if (listener.Status == ListenerStates.PAUSED)
                {
                    itm.BackColor = Color.LightGray;
                }

                lstBrowse.Items.Add(itm);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Could not add listener to browse table.");
            }

        }

        public void ClearList()
        {
            lstFreeze.Items.Clear();
            lstBrowse.Items.Clear();
        }

        public void RefreshList()
        {
            ClearList();

            foreach (var listener in listeners.Skip(page).Take(pageSize))
            {
                AddToListeners(listener);
            }
        }

        private void btnCancelStop_Click(object sender, EventArgs e)
        {
            if (selectedListener != null)
            {
                try
                {
                    selectedListener.Resume();

                    serviceLayer.UpdateListener(selectedListener);
                    Interaction.MsgBox("Succesfully updated listener.");
                    log.Info("Resumed and updated listener with WalletId: " + selectedListener.Wallet);
                    UpdateListeners();
                }
                catch (ListenerStateChangeException ex)
                {
                    log.Error(ex, "Attempt to resume non paused listener! WalletId: " + selectedListener.Wallet);
                    Interaction.MsgBox("This listener is not Paused.");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedListener != null)
            {
                My.MyProject.Forms.formEdit.Show();
                My.MyProject.Forms.formEdit.setupForm(selectedListener);
            }
        }

        private void btnStopSending_Click(object sender, EventArgs e)
        {
            if (selectedListener != null)
            {
                My.MyProject.Forms.formStopSending.Show();
                My.MyProject.Forms.formStopSending.setupForm(selectedListener);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedListener != null)
            {
                var deleteForm = FormDelete.Create(selectedListener);

                var deleteResult = deleteForm.ShowDialog();
                if (deleteResult == DialogResult.OK)
                {
                    UpdateListeners();
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            page = 0;
            RefreshList();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            page = Math.Max(page - pageSize, 0);
            RefreshList();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            page = Math.Min(page + pageSize, listeners.Count - pageSize);
            RefreshList();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            page = listeners.Count - pageSize;
            RefreshList();
        }

        private void AddHorribleHeaders()
        {
            int weekNumber = serviceLayer.GetCurrentWeekNumber();

            for (int count = 1; count <= 4; count++)
            {
                int final = weekNumber - (4 - count);
                lstBrowse.Columns.Add(final + " (IN)");
            }
            for (int count = 1; count <= 4; count++)
            {
                int final = weekNumber - (4 - count);
                lstBrowse.Columns.Add(final + " (OUT)");
            }
        }

        private void formBrowse_Load(object sender, EventArgs e)
        {
            AddHorribleHeaders();
            UpdateOrder();
            UpdateListeners();
        }

        private void UpdateListeners()
        {
            var order = cmbOrder.Text.Equals("Wallet") ? OrderVar.WALLET : OrderVar.SURNAME;
            listeners = serviceLayer.GetOrderedListeners(order)
                .Where(x => (showDeleted && x.Status == ListenerStates.DELETED) ||
                            (!showDeleted && x.Status != ListenerStates.DELETED))
                .ToList();
            RefreshList();
        }

        private void cmbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        public FormBrowse()
        {
            Load += formBrowse_Load;
            InitializeComponent();
        }

        private void lstBrowse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBrowse.FocusedItem != null)
            {
                lstFreeze.Items[lstBrowse.FocusedItem.Index].Focused = true;
                lstFreeze.Items[lstBrowse.FocusedItem.Index].Selected = true;
                lstFreeze.Select();
                lstFreeze.Focus();
                lstBrowse.Focus();
            }
        }

        private void lstFreeze_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFreeze.FocusedItem != null)
            {
                lstBrowse.Items[lstFreeze.FocusedItem.Index].Focused = true;
                lstBrowse.Items[lstFreeze.FocusedItem.Index].Selected = true;
                lstBrowse.Select();
                lstBrowse.Focus();
                lstFreeze.Focus();
                SelectItem(lstFreeze.FocusedItem.Index);
            }
        }

        private void SelectItem(int index)
        {
            var wallet = int.Parse(lstFreeze.Items[index].Text);
            selectedListener = serviceLayer.GetListenerById(wallet);

            // Buttons only available if required.
            btnRemove.Enabled = !selectedListener.Status.Equals(ListenerStates.DELETED);
            btnStopSending.Enabled = selectedListener.Status.Equals(ListenerStates.ACTIVE);
            btnCancelStop.Enabled = selectedListener.Status.Equals(ListenerStates.PAUSED);
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            showDeleted = !showDeleted;
            filterButton.Text = showDeleted ? "Show Active" : "Show Deleted";
            page = 0;
            UpdateListeners();
        }
    }
}
