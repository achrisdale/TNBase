namespace TNBase.App.Test;

public class SettingsServiceTests
{
    [Fact]
    public void GetSettingDefinitions_ShouldReturnDefinitions()
    {
        var serivce = new SettingsService();

        var result = serivce.GetSettingDefinitions();

        Assert.True(result.Count > 0);
    }
}
