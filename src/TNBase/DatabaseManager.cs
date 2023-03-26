using Microsoft.Data.Sqlite;
using NLog;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TNBase.DataStorage;
using TNBase.Forms;
using TNBase.Repository;
using System.Security.Cryptography;

namespace TNBase
{
    public class DatabaseManager
    {
        private const string DATABASE_FILE_NAME = "Listeners.s3db";
        private const string DATABASE_PASSWORD_FILE = "System.txt";

        private readonly DatabaseManagerOptions options;
        private readonly Logger log = LogManager.GetCurrentClassLogger();

        private ITNBaseContext database;

        public DatabaseManager(DatabaseManagerOptions options)
        {
            this.options = options;
        }

        public ITNBaseContext Database
        {
            get
            {
                if (database == null)
                {
                    database = GetDatabaseContext();
                }

                return database;
            }
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
                    if (!DBUtils.CopyDatabase(Path.Combine(options.DataLocation, DATABASE_FILE_NAME), fullbackuppath))
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

        private ITNBaseContext GetDatabaseContext()
        {
            var databaseFile = Path.Combine(options.DataLocation, DATABASE_FILE_NAME);
            log.Info($"Connecting to database '{databaseFile}'");

            if (!File.Exists(databaseFile))
            {
                log.Warn("Database not found. New database will be created.");
                // Consider asking for encryption password here
            }

            var password = GetDatabasePassword();
            var connectionStringBuilder = new SqliteConnectionStringBuilder()
            {
                DataSource = databaseFile,
                Mode = SqliteOpenMode.ReadWriteCreate,
                Password = password
            };

            try
            {
                var connection = new SqliteConnection(connectionStringBuilder.ToString());
                connection.Open();

                var hasPassword = !string.IsNullOrEmpty(password);
                var context = new TNBaseContext(connection, hasPassword);
                log.Info($"Connected to database successfully");
                return context;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Failed to connect to database. Requesting for password.");

                var form = new FormDatabasePassword();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SaveDatabasePassword(form.Password);
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

        public void EncryptDatabase(string password)
        {
            log.Info($"Encrypting database...");
            var tempDatabase = Path.Combine(options.DataLocation, "Temp.s3db");
            if (File.Exists(tempDatabase))
            {
                File.Delete(tempDatabase);
            }

            var commands = Database.Connection.CreateCommand();
            commands.CommandText = $"ATTACH DATABASE '{tempDatabase}' AS encrypted KEY '{password}';";
            commands.ExecuteNonQuery();
            commands.CommandText = "SELECT sqlcipher_export('encrypted');";
            commands.ExecuteNonQuery();
            commands.CommandText = "DETACH DATABASE encrypted";
            commands.ExecuteNonQuery();
            log.Debug($"Created temporary database with new encryption.");

            SaveDatabasePassword(password);
            RestoreDatabase(tempDatabase);

            if (File.Exists(tempDatabase))
            {
                File.Delete(tempDatabase);
            }

            log.Info($"Database encryption complete.");
        }

        private string GetDatabasePassword()
        {
            var encryptedPasswordFile = Path.Combine(options.DataLocation, DATABASE_PASSWORD_FILE);
            if (!File.Exists(encryptedPasswordFile))
            {
                log.Debug($"No database password found on the system.");
                return string.Empty;
            }

            var encrypted = File.ReadAllBytes(encryptedPasswordFile);
            var decrypted = ProtectedData.Unprotect(encrypted, GetEntropy(), DataProtectionScope.LocalMachine);
            var password = Encoding.ASCII.GetString(decrypted);

            log.Debug($"Retrieved database password from the system.");
            return password;
        }

        private void SaveDatabasePassword(string password)
        {
            var encryptedPasswordFile = Path.Combine(options.DataLocation, DATABASE_PASSWORD_FILE);
            if (string.IsNullOrWhiteSpace(password))
            {
                if (File.Exists(encryptedPasswordFile))
                {
                    File.Delete(encryptedPasswordFile);
                    log.Info($"Database password is removed from the system.");
                }

                return;
            }

            var toEncrypt = Encoding.ASCII.GetBytes(password);
            var encrypted = ProtectedData.Protect(toEncrypt, GetEntropy(), DataProtectionScope.LocalMachine);
            File.WriteAllBytes(encryptedPasswordFile, encrypted);
            log.Info($"New database password is stored.");
        }

        private static byte[] GetEntropy()
        {
            return Encoding.ASCII.GetBytes("IntendedObscurity");
        }

        internal bool BackupDatabase(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool RestoreDatabase(string fileName)
        {
            log.Debug($"Restoring database from '{fileName}'");
            var databasePath = Path.Combine(options.DataLocation, DATABASE_FILE_NAME);
            File.Copy(fileName, databasePath, true);

            var context = (TNBaseContext)GetDatabaseContext();
            if(context == null)
            {
                log.Error($"Could not load database context after database restoration. Please check password and try again.");
                return false;
            }

            context.UpdateDatabase();
            database = context;

            Program.NewScope();

            log.Info($"Database restored from '{fileName}'");
            return true;
        }
    }

    public class DatabaseManagerOptions
    {
        public string DataLocation { get; internal set; }
    }
}
