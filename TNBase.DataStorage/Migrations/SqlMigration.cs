using NLog;
using System;
using System.Data.SQLite;

namespace TNBase.DataStorage.Migrations
{
    public abstract class SqlMigration
    {
        private Logger log = LogManager.GetCurrentClassLogger();
        private readonly SQLiteConnection connection;

        public SqlMigration(SQLiteConnection connection)
        {
            this.connection = connection;
        }

        protected void Sql(string query)
        {
            log.Debug("Executing query: " + query);
            using (var command = connection.CreateCommand())
            {
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
        }

        public abstract void Up();
    }
}
