using NLog.Fluent;
using System.Collections.Generic;
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

    public void PurgeOverdueDeletedListeners()
    {
        var listeners = context.Listeners
            .ToList() // needed to avoid reference error
            .Where(x => x.Status.Equals(ListenerStates.DELETED) && x.DeletedDate < timeProvider.UtcNow.AddDays(-options.DaysBeforePurgeDeletedListeners))
            .ToList();

        foreach (var listener in listeners)
        {
            var records = context.InOutRecords.SingleOrDefault(x=>x.Wallet == listener.Wallet);
            context.InOutRecords.Remove(records);

            log.Info($"Purging listener with id {listener.Wallet} as they have been marked as deleted for over {options.DaysBeforePurgeDeletedListeners} days.");
            context.Listeners.Remove(listener);
        }

        context.SaveChanges();
    }

}
