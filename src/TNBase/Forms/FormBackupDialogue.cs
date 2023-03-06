using System;
using System.Windows.Forms;

namespace TNBase.Forms
{
    public partial class FormBackupDialogue : Form
    {
        public FormBackupDialogue()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

            }

            //backupDialog.FileName = ModuleGeneric.DATABASE_NAME;
            //backupDialog.Title = "Backup Listener Database";
            //backupDialog.Filter = "SQLite Database Files|*.s3db";
            //backupDialog.CheckPathExists = true;
            //backupDialog.InitialDirectory = "A:\\";
            //backupDialog.OverwritePrompt = Properties.Settings.Default.OverwritePrompt;

            //if (backupDialog.ShowDialog() == DialogResult.OK)
            //{
            //    var databaseManager = Program.ServiceProvider.GetService<DatabaseManager>();
            //    if (databaseManager.BackupDatabase(backupDialog.FileName))
            //    {
            //        Interaction.MsgBox("Database backup completed successfully.");
            //    }
            //    else
            //    {
            //        Interaction.MsgBox("Error: Database was not copied correctly!");
            //    }
            //}

        }
    }
}
