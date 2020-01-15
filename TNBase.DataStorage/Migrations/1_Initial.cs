using System;
using System.Data.SQLite;

namespace TNBase.DataStorage.Migrations
{
    public class _1_Initial : SqlMigration
    {
        public _1_Initial(SQLiteConnection connection) : base(connection)
        { }

        public override void Up()
        {
        }
    }
}
