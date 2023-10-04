using System.Linq;
using TNBase.Domain;

namespace TNBase.App;

public class DataSweeper
{
    static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

    private readonly ITNBaseContext context;
    private readonly DataSweeperOptions options;
    private readonly ITimeProvider timeProvider;

    public DataSweeper(ITNBaseContext context, DataSweeperOptions options, ITimeProvider timeProvider)
    {
        this.context = context;
        this.options = options;
        this.timeProvider = timeProvider;
    }

    public void PurgeReservedWallets()
    {
        log.Info($"Purging listeners deleted over {options.DaysBeforePurgeReservedWallets} days ago.");

        var listeners = context.Listeners
            .ToList() // needed to avoid reference error
            .Where(x => x.Status.Equals(ListenerStates.RESERVED) && x.ReservedDate < timeProvider.UtcNow.AddDays(-options.DaysBeforePurgeReservedWallets))
            .ToList();

        if(!listeners.Any())
        {
            log.Info($"No listeners found to purge.");
            return;
        }

        foreach (var listener in listeners)
        {
            log.Info($"Purging listener with id {listener.Wallet} as they have been marked as deleted for over {options.DaysBeforePurgeReservedWallets} days.");

            context.InOutRecords.Remove(listener.InOutRecords);
            context.Listeners.Remove(listener);
        }

        context.SaveChanges();
    }
}
