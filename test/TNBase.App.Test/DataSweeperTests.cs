using FluentAssertions;
using System;
using System.Linq;
using TNBase.Domain;

namespace TNBase.App.Test;

public class DataSweeperTests
{
    [Theory]
    [InlineData("23/04/2023", 4, "10/04/2023")]
    [InlineData("01/01/2021", 365, "01/01/2020")]
    [InlineData("23/04/2023", 1, "21/04/2023")]
    public void PurgeDeletedListeners_ShouldRemoveListeners_WhenDeletedDatePastPurgeDate(string testDate, int daysBeforePurge, string deletedOn)
    {
        var builder = new DataSweeperBuilder();
        var sweeper = builder
            .WithTestDate(testDate)
            .WithDaysBeforePurgeDeletedListeners(daysBeforePurge)
            .WithListenerDeletedOn(deletedOn)
            .Build();

        sweeper.PurgeDeletedListeners();

        builder.Context.Listeners.Should().HaveCount(0);
    }

    [Theory]
    [InlineData("23/04/2023", 15, "10/04/2023")]
    [InlineData("31/12/2020", 365, "01/01/2020")]
    [InlineData("23/04/2023", 1, "22/04/2023")]
    public void PurgeDeletedListeners_ShouldNotRemoveListeners_WhenDeletedDateBeforePurgeDate(string testDate, int daysBeforePurge, string deletedOn)
    {
        var builder = new DataSweeperBuilder();
        var sweeper = builder
            .WithTestDate(testDate)
            .WithDaysBeforePurgeDeletedListeners(daysBeforePurge)
            .WithListenerDeletedOn(deletedOn)
            .Build();

        sweeper.PurgeDeletedListeners();

        builder.Context.Listeners.Should().HaveCount(1);
    }

    [Fact]
    public void PurgeDeletedListeners_ShouldNotRemoveActiveListeners_WhenPurgingDeletedListeners()
    {
        var builder = new DataSweeperBuilder();
        var sweeper = builder
            .WithTestDate("23/04/2023")
            .WithDaysBeforePurgeDeletedListeners(10)
            .WithListenerDeletedOn("10/04/2023")
            .WithListener(ListenerStates.ACTIVE)
            .WithListener(ListenerStates.PAUSED)
            .Build();

        sweeper.PurgeDeletedListeners();

        builder.Context.Listeners.Should().HaveCount(2);
        builder.Context.Listeners.Where(x => x.Status == ListenerStates.DELETED).Should().HaveCount(0);
    }

    [Fact]
    public void PurgeDeletedListeners_ShouldDoNothing_WhenNoListenersAvailableToPurge()
    {
        var builder = new DataSweeperBuilder();
        var sweeper = builder
            .WithTestDate("23/04/2023")
            .WithDaysBeforePurgeDeletedListeners(10)
            .WithListener(ListenerStates.ACTIVE)
            .WithListener(ListenerStates.ACTIVE)
            .WithListener(ListenerStates.PAUSED)
            .WithListener(ListenerStates.PAUSED)
            .Build();

        sweeper.PurgeDeletedListeners();

        builder.Context.Listeners.Should().HaveCount(4);
    }
}
