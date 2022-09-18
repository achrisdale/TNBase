using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows.Forms;

namespace TNBase.Forms
{
    public partial class FormDataImport : Form
    {
        public FormDataImport()
        {
            InitializeComponent();
        }

        private void ImportListenersButton_Click(object sender, EventArgs e)
        {

        }

        private void DownloadListenersTemplateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "CSV Text|*.csv";
            dialog.Title = "Save Listeners Import Template";
            dialog.FileName = "Listeners Import Template.csv";
            dialog.ShowDialog();

            if (!string.IsNullOrWhiteSpace(dialog.FileName))
            {
                var resourceManager = Program.ServiceProvider.GetService<ResourceManager>();
                File.Copy(resourceManager.ListenersImportTemplatePath, dialog.FileName, true);
            }
        }
    }
}
