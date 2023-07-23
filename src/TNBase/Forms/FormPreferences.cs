using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TNBase.DataStorage;
using TNBase.DataStorage.Service;
using TNBase.Objects;

namespace TNBase.Forms
{
    public partial class FormPreferences : Form
    {
        private readonly PreferencesService preferencesService = Program.ServiceProvider.GetRequiredService<PreferencesService>();
        private Preferences preferences;

        public FormPreferences()
        {
            InitializeComponent();
        }

        private void FormPreferences_Load(object sender, EventArgs e)
        {
            preferences = preferencesService.GetPreferences();

            ApplicationTitleTextBox.Text = preferences.ApplicationTitle;
            LogoFileNameTextBox.Text = preferences.LogoFileName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            preferences.ApplicationTitle = ApplicationTitleTextBox.Text;
            preferences.LogoFileName = LogoFileNameTextBox.Text;
            preferencesService.UpdatePreferences(preferences);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnSelectLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select logo";
            ofd.Filter = "Image (*.bmp,*.jpg,*.png)|*.bmp;*.jpg;*.png";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                LogoFileNameTextBox.Text = ofd.FileName;
            }
        }
    }
}
