using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TNBase.Domain;

namespace TNBase.DataStorage
{
    public interface ITNBaseContext
    {
        SqliteConnection Connection { get; }
        bool IsEncrypted { get; }

        DbSet<Collector> Collectors { get; set; }
        DbSet<Listener> Listeners { get; set; }
        DbSet<Scan> Scans { get; set; }
        DbSet<WeeklyStats> WeeklyStats { get; set; }
        DbSet<YearStats> YearStats { get; set; }
        DbSet<InOutRecords> InOutRecords { get; set; }

        int SaveChanges();
    }
}