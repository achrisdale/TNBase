using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNBase.Repository.Migrations
{
    public class _9_Preferences : SqlMigration
    {
        public _9_Preferences(SqliteConnection connection) : base(connection)
        { }

        public override void Up()
        {
            using var command = connection.CreateCommand();

            command.CommandText = @"CREATE TABLE IF NOT EXISTS [Preferences] ([Key] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [ApplicationTitle] text NOT NULL, 
                                    [LogoFileName] text NOT NULL)";
            command.ExecuteNonQuery();
        }
    }
}

