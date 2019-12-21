using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using TNBase.Objects;
using NLog;
using TNBase.DataStorage;
using TNBase.Forms;

namespace TNBase
{
	public partial class FormAddCollectors
	{
        // Logging instance.
		private Logger log = LogManager.GetCurrentClassLogger();

        IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

		int id = 0;

		bool editMode = false;
		public void setupEditMode(Collector col)
		{
			try {
				log.Debug("Setting up edit form.");
				editMode = true;

				id = col.ID;
				txtForename.Text = col.Forename;
				txtSurname.Text = col.Surname;
				txtTelephone.Text = col.Number;
				string tempStr = col.Postcodes;

				string[] parts = Strings.Split(tempStr, ",");
				foreach (string part in parts) 
                {
					lstPostcodes.Items.Add(part);
				}
			} catch (Exception ex) {
				log.Error(ex, "Failed to setup form.");
				MessageBox.Show("Error: Failed to setup form!", ModuleGeneric.getAppShortName());
				this.Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			log.Trace("Cancelling and closing form, user has clicked cancel.");
			this.Close();
		}

		private void btnFinished_Click(object sender, EventArgs e)
		{
			Collector col = new Collector();

			if (editMode) {
				col.ID = id;
			}

			// Check we have some data.
			if (string.IsNullOrEmpty(txtForename.Text) | string.IsNullOrEmpty(txtSurname.Text) | string.IsNullOrEmpty(txtTelephone.Text) | lstPostcodes.Items.Count == 0) {
				log.Error("Empty value/incomplete form. Forename: " + col.Forename + ", Surname: " + col.Surname + ", Number: " + col.Number);
				MessageBox.Show("Incomplete form.", ModuleGeneric.getAppShortName());
				return;
			}

			col.Forename = txtForename.Text;
			col.Surname = txtSurname.Text;
			col.Number = txtTelephone.Text;

			// Convert to csv.
			string combined = "";
			for (int index = 0; index <= lstPostcodes.Items.Count - 1; index++) {
				combined += lstPostcodes.Items[index] + ",";
			}
			// String last comma.
			combined = combined.Substring(0, combined.Length - 1);

			col.Postcodes = combined;
			// Add the collector.

			if (editMode) {
				if (!serviceLayer.UpdateCollector(col)) {
					MessageBox.Show("Error: could not update collector in database!", ModuleGeneric.getAppShortName());
					log.Error("Could not update collector in database!");
				} else {
					MessageBox.Show("Successfully updated collector.", ModuleGeneric.getAppShortName());
					log.Trace("Successfully updated collector.");
				}
			} else {
				if (!serviceLayer.AddCollector(col)) {
					MessageBox.Show("Error: could not add collector to database!", ModuleGeneric.getAppShortName());
					log.Error("Could not add collector to database!");
				} else {
					MessageBox.Show("Successfully added collector.", ModuleGeneric.getAppShortName());
					log.Trace("Successfully added collector.");
				}
			}

			log.Trace("Closing form.");
			this.Close();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			try {
				if (lstPostcodes.Items.Count > 0) {
					lstPostcodes.Items.Remove(lstPostcodes.SelectedItem);
				} else {
					log.Trace("Attempted to remove item but no items exist.");
				}
			} catch (Exception ex) {
				log.Warn(ex, "Failed to delete item.");
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string result = new FormInput().ShowDialog("Enter a postcode:" + Environment.NewLine + 
                                                 "You can enter [A-H] after the postcode to specify the collector will only collect for listeners surnames starting A-H" + Environment.NewLine +
                                                 "Example postcode: CF14 [A-Z]");

            try
            {
                Utils.validatePostcode(result);

                lstPostcodes.Items.Add(result);
            } 
            catch (Exception ex) 
            {
                log.Error(ex, "Could not validate postcode" + ex.Message);
                MessageBox.Show("Could not validate postcode: " + ex.Message, ModuleGeneric.getAppShortName());
            }
		}

		public FormAddCollectors()
		{
			InitializeComponent();
		}
	}
}
