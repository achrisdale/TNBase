
using Microsoft.Data.Sqlite;

namespace TNBase.Repository.Migrations
{
    /// <summary>
    /// Fix ScanIn history record data issue
    /// </summary>
    public class _9_AnonimizeDate : SqlMigration
    {
        public _9_AnonimizeDate(SqliteConnection connection) : base(connection)
        { }

        public override void Up()
        {
            using var command = connection.CreateCommand();

            command.CommandText = $"ALTER TABLE Listeners ADD ReservedDate DATE NULL";
            command.ExecuteNonQuery();

            command.CommandText = $@"UPDATE Listeners SET 
                                            Status='RESERVED',
                                            ReservedDate=DeletedDate
                                        WHERE Status='DELETED' AND 
                                            Forename='Deleted' AND 
                                            Surname='Deleted'";
            command.ExecuteNonQuery();
        }
    }
}
