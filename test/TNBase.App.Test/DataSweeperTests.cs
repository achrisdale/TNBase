using FluentAssertions;
using System.Linq;
using TNBase.Domain;

namespace TNBase.App.Test;

public class DataSweeperTests
{
    [Theory]
    [InlineData("23/04/2023", 4, "10/04/2023")]
    [InlineData("01/01/2021", 365, "01/01/2020")]
    [InlineData("23/04/2023", 1, "21/04/2023")]
    public void PurgeDeletedListeners_ShouldRemoveListeners_WhenReservedDatePastPurgeDate(string testDate, int daysBeforePurge, string reservedOn)
    {
        var builder = new DataSweeperBuilder();
        var sweeper = builder
            .WithTestDate(testDate)
            .WithDaysBeforePurgeReservedWallets(daysBeforePurge)
            .WithListenerReservedOn(reservedOn)
            .Build();

        sweeper.PurgeReservedWallets();

        builder.Context.Listeners.Should().HaveCount(0);
    }

    [Theory]
    [InlineData("23/04/2023", 15, "10/04/2023")]
    [InlineData("31/12/2020", 365, "01/01/2020")]
    [InlineData("23/04/2023", 1, "22/04/2023")]
    public void PurgeDeletedListeners_ShouldNotRemoveListeners_WhenReservedDateBeforePurgeDate(string testDate, int daysBeforePurge, string reservedOn)
    {
        var builder = new DataSweeperBuilder();
        var sweeper = builder
            .WithTestDate(testDate)
            .WithDaysBeforePurgeReservedWallets(daysBeforePurge)
            .WithListenerReservedOn(reservedOn)
            .Build();

        sweeper.PurgeReservedWallets();

        builder.Context.Listeners.Should().HaveCount(1);
    }

    [Fact]
    public void PurgeDeletedListeners_ShouldNotRemoveActiveListeners_WhenPurgingReservedWallets()
    {
        var builder = new DataSweeperBuilder();
        var sweeper = builder
            .WithTestDate("23/04/2023")
            .WithDaysBeforePurgeReservedWallets(10)
            .WithListenerReservedOn("10/04/2023")
            .WithListener(ListenerStates.ACTIVE)
            .WithListener(ListenerStates.PAUSED)
            .WithListener(ListenerStates.DELETED, "01/01/2023")
            .Build();

        sweeper.PurgeReservedWallets();

        builder.Context.Listeners.Should().HaveCount(3);
        builder.Context.Listeners.Where(x => x.Status == ListenerStates.RESERVED).Should().HaveCount(0);
    }

    [Fact]
    public void PurgeDeletedListeners_ShouldDoNothing_WhenNoWalletsAvailableToPurge()
    {
        var builder = new DataSweeperBuilder();
        var sweeper = builder
            .WithTestDate("23/04/2023")
            .WithDaysBeforePurgeReservedWallets(10)
            .WithListener(ListenerStates.ACTIVE)
            .WithListener(ListenerStates.ACTIVE)
            .WithListener(ListenerStates.PAUSED)
            .WithListener(ListenerStates.PAUSED)
            .WithListener(ListenerStates.DELETED, "01/01/2023")
            .Build();

        sweeper.PurgeReservedWallets();

        builder.Context.Listeners.Should().HaveCount(5);
    }
}
