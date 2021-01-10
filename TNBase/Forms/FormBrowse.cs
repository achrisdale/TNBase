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
        private bool showRemoved = false;

        private void btnDone_Click(object sender, EventArgs e)
        {
            Close();
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
                if (listener.Status == ListenerStates.REMOVED)
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

        public void ClearForm()
        {
            lstFreeze.Items.Clear();
            lstBrowse.Items.Clear();
            selectedListener = null;
            UpdateFormControls();
        }

        private IEnumerable<Listener> GetOrderedListeners()
        {
            if (cmbOrder.Text.Equals("Wallet"))
                return listeners.OrderBy(x => x.Wallet);

            return listeners.OrderBy(x => x.Surname);
        }

        public void RefreshList()
        {
            ClearForm();

            foreach (var listener in GetOrderedListeners().Skip(page).Take(pageSize))
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
                var form = FormEdit.Create(selectedListener);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateListeners();
                }
            }
        }

        private void btnStopSending_Click(object sender, EventArgs e)
        {
            if (selectedListener != null)
            {
                if (selectedListener.CanPause())
                {
                    var form = FormStopSending.Create(selectedListener);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        UpdateListeners();
                    }
                }
                else if (selectedListener.CanResume())
                {
                    selectedListener.Resume();

                    serviceLayer.UpdateListener(selectedListener);
                    Interaction.MsgBox("Succesfully updated listener.");
                    log.Info("Resumed and updated listener with WalletId: " + selectedListener.Wallet);
                    UpdateListeners();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedListener != null)
            {
                var form = FormDelete.Create(selectedListener);
                if (form.ShowDialog() == DialogResult.OK)
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
            UpdateListeners();
        }

        private void UpdateListeners()
        {
            listeners = serviceLayer.GetListeners()
                .Where(x => (showRemoved && x.Status == ListenerStates.REMOVED) ||
                            (!showRemoved && (x.Status == ListenerStates.ACTIVE || x.Status == ListenerStates.PAUSED)))
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
            UpdateFormControls();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            showRemoved = !showRemoved;
            filterButton.Text = showRemoved ? "Show active listeners" : "Show marked for deletion";
            page = 0;
            UpdateListeners();
        }

        private void UpdateFormControls()
        {
            if (selectedListener == null)
            {
                btnEdit.Visible = false;
                btnRemove.Visible = false;
                btnStopSending.Visible = false;
            }
            else
            {
                btnEdit.Visible = selectedListener.CanEdit();
                btnRemove.Visible = selectedListener.CanDelete();

                if (selectedListener.CanPause())
                {
                    btnStopSending.Text = "Stop sending";
                    btnStopSending.Visible = true;
                }
                else if (selectedListener.CanResume())
                {
                    btnStopSending.Text = "Cancel a stop";
                    btnStopSending.Visible = true;
                }
            }
        }
    }
}
