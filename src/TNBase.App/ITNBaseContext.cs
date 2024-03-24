using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TNBase.Domain;

namespace TNBase.App
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
        DbSet<Setting> Settings { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}