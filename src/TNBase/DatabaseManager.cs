using Microsoft.Data.Sqlite;
using NLog;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TNBase.DataStorage;
using TNBase.Forms;
using TNBase.Repository;

namespace TNBase
{
    public class DatabaseManager
    {
        private readonly DatabaseManagerOptions options;
        private readonly Logger log = LogManager.GetCurrentClassLogger();

        public DatabaseManager(DatabaseManagerOptions options)
        {
            this.options = options;
        }

        public void BackupDatabase()
        {
            var drives = DriveInfo.GetDrives().ToList();

            bool found = false;
            string path = "";
            foreach (DriveInfo drive in drives)
            {
                try
                {
                    if (drive.VolumeLabel.Equals(Properties.Settings.Default.BackupDrive) || drive.Name.Equals(Properties.Settings.Default.BackupDrive))
                    {
                        path = drive.RootDirectory.ToString() + Application.ProductName + "\\backups\\";
                        Directory.CreateDirectory(path);

                        if (drive.AvailableFreeSpace < (Properties.Settings.Default.BackupMBSpaceWarning * 1000000))
                        {
                            MessageBox.Show("Warning: Low space available on backup drive: " + Properties.Settings.Default.BackupDrive, Application.ProductName, MessageBoxButtons.OK);
                            log.Warn("Warning: Low space available on backup drive: " + Properties.Settings.Default.BackupDrive);
                        }

                        found = true;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    log.Trace(ex, "Error loading drive labels: ");
                }
            }

            if (found)
            {
                try
                {
                    String fullbackuppath = path + Application.ProductName + "_backup_" + DateTime.Now.ToString("dd-MM-yyyy") + ".bak";
                    if (!DBUtils.CopyDatabase(options.DatabasePath, fullbackuppath))
                    {
                        MessageBox.Show("Warning: Could not backup database: " + Properties.Settings.Default.BackupDrive, Application.ProductName, MessageBoxButtons.OK);
                        log.Warn("Could not backup database: " + fullbackuppath);
                    }
                    else
                    {
                        log.Info("Backed up database to: " + fullbackuppath);
                    }
                }
                catch (Exception ey)
                {
                    log.Warn(ey, "Could not backup database.");
                }
            }
            else
            {
                MessageBox.Show("Warning: Could not find the backup drive: " + Properties.Settings.Default.BackupDrive, Application.ProductName, MessageBoxButtons.OK);
                log.Warn("Could not find resources folder.");
            }
        }

        public ITNBaseContext GetDatabaseContext()
        {
            log.Info($"Connecting to database '{options.DatabasePath}'");

            if (!File.Exists(options.DatabasePath))
            {
                log.Warn("Database not found. New database will be created.");
                // Consider asking for encryption password here
            }

            var connectionStringBuilder = new SqliteConnectionStringBuilder()
            {
                DataSource = options.DatabasePath,
                Mode = SqliteOpenMode.ReadWriteCreate,
                Password = GetEncryptionPassword()
            };

            try
            {
                var connection = new SqliteConnection(connectionStringBuilder.ToString());
                connection.Open();

                var context = new TNBaseContext(connection);
                return context;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Failed to connect to database. Requesting for password.");

                var form = new FormSetDatabaseEncryptionKey();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SetEncryptionPassword(form.Password);
                    return GetDatabaseContext();
                }

                log.Error("'Set Database Encryption Key' dialog did not return success. Unable to connect to database.");
                return null;
            }

            //    m = new SqliteConnectionStringBuilder(connectionString)
            //    {
            //        Mode = SqliteOpenMode.ReadWriteCreate
            //    };

            //    connection = new SqliteConnection(m.ToString());
            //    connection.Open();

            //    var commands = connection.CreateCommand();
            //    commands.CommandText = "ATTACH DATABASE 'encrypted.db' AS encrypted KEY 'newkey';";
            //    commands.ExecuteNonQuery();
            //    commands.CommandText = "SELECT sqlcipher_export('encrypted');";
            //    commands.ExecuteNonQuery();
            //    commands.CommandText = "DETACH DATABASE encrypted";
            //    commands.ExecuteNonQuery();

            //    connection.Close();
            //    connection.Dispose();

            //    m = new SqliteConnectionStringBuilder($"Data Source=encrypted.db")
            //    {
            //        Mode = SqliteOpenMode.ReadWriteCreate,
            //        Password = "newkey"
            //    };

            //    connection = new SqliteConnection(m.ToString());
            //    connection.Open();
            //}
        }

        private string GetEncryptionPassword()
        {
            return "b";
        }

        public void SetEncryptionPassword(string password)
        {

        }

        internal bool BackupDatabase(string fileName)
        {
            throw new NotImplementedException();
        }

        internal bool RestoreDatabase(string fileName)
        {
            throw new NotImplementedException();
        }
    }

    public class DatabaseManagerOptions
    {
        public string DatabasePath { get; set; }
    }
}
