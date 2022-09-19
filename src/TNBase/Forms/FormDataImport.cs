using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TNBase.External.DataImport;

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
            var dialog = new OpenFileDialog
            {
                Filter = "CSV Text|*.csv",
                Title = "Select File to Import Listeners",
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var content = File.ReadAllText(dialog.FileName, Encoding.UTF8);
                var importService = Program.ServiceProvider.GetService<CsvImportService>();

                try
                {
                    var result = importService.ImportListeners(content);
                    var reportForm = new FormDataImportReport(result);
                    reportForm.ShowDialog();
                    Close();
                }
                catch (InvalidImportDataException ex)
                {
                    MessageBox.Show(ex.Message, "Listener Import Error");
                }
            }

        }

        private void DownloadListenersTemplateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "CSV Text|*.csv",
                Title = "Save Listeners Import Template",
                FileName = "Listeners Import Template.csv"
            };

            dialog.ShowDialog();

            if (!string.IsNullOrWhiteSpace(dialog.FileName))
            {
                var resourceManager = Program.ServiceProvider.GetService<ResourceManager>();
                File.Copy(resourceManager.ListenersImportTemplatePath, dialog.FileName, true);
            }
        }
    }
}
