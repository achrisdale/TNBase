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
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"ALTER TABLE Listeners ADD MagazineWallet TEXT";
                command.ExecuteNonQuery();

                command.CommandText = $"ALTER TABLE Listeners ADD MagazineStock TEXT";
                command.ExecuteNonQuery();
            }
        }
    }
}
