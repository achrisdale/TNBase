﻿using System.Data;
using System.Data.SQLite;

namespace TNBase.DataStorage.Migrations
{
    public class _3_MaskDeletedListeners : SqlMigration
    {
        public _3_MaskDeletedListeners(SQLiteConnection connection) : base(connection)
        { }

        public override void Up()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"UPDATE Listeners SET Status='REMOVED' WHERE Status='DELETED' AND MemStickPlayer=true";
                command.ExecuteNonQuery();

                command.CommandText = $"UPDATE Listeners SET Title='N/A', Forename='Deleted', Surname='Deleted', Addr1=null, Addr2=null, Town=null, County=null, Postcode=null, Telephone=null, Joined=null, Birthday=null, Info=null WHERE Status='DELETED' AND MemStickPlayer=false";
                command.ExecuteNonQuery();
            }
        }
    }
}
