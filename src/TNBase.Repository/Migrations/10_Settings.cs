
using Microsoft.Data.Sqlite;

namespace TNBase.Repository.Migrations
{
    /// <summary>
    /// Fix ScanIn history record data issue
    /// </summary>
    public class _10_Settings : SqlMigration
    {
        public _10_Settings(SqliteConnection connection) : base(connection)
        { }

        public override void Up()
        {
            using var command = connection.CreateCommand();

            command.CommandText = $"CREATE TABLE [Settings] ([Key] Text UNIQUE NOT NULL, [Value] Text NULL)";
            command.ExecuteNonQuery();

            command.CommandText = $"CREATE INDEX settings_key ON [Settings] (Key)";
            command.ExecuteNonQuery();
        }
    }
}
