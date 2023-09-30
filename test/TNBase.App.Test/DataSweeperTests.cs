using FluentAssertions;
using System.Linq;
using TNBase.Domain;

namespace TNBase.App.Test;

public class DataSweeperTests
{
    [Fact]
    public void PurgeDeletedListeners_ShouldRemoveListeners_WhenDeletedDatePastPurgeDate()
    {
        var builder = new DataSweeperBuilder();
        var sweeper = builder
            .WithTestDate("23/04/2023")
            .WithDaysBeforePurgeDeletedListeners(4)
            .WithListenerDeletedOn("10/04/2023")
            .Build();

        sweeper.PurgeOverdueDeletedListeners();
        
        builder.Context.Listeners.Should().HaveCount(0);
    }
}
