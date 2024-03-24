using System.Linq;
using System.Threading.Tasks;
using TNBase.Repository;

namespace TNBase.App.Test;

public class SettingsServiceTests
{
    private TNBaseContext contex;

    public SettingsServiceTests()
    {
        contex = new TNBaseContext("Data Source=:memory:");
        contex.UpdateDatabase();
    }

    [Fact]
    public void GetSettingDefinitions_ShouldReturnDefinitions()
    {
        var serivce = new SettingsService(contex);

        var result = serivce.GetSettingDefinitions();

        Assert.True(result.Count > 0);
    }

    [Fact]
    public void GetSettings_ShouldReturnDefinedSettings()
    {
        var serivce = new SettingsService(contex);
        var definitions = serivce.GetSettingDefinitions();

        var result = serivce.GetSettings();

        Assert.Equal(definitions.Count, result.Count);
        Assert.Equal(definitions.Select(x => x.Key).ToList(), result.Select(x => x.Key).ToList());
    }

    [Fact]
    public void GetSettings_WhenSettingDoesNotExist_ShouldReturnSettingWithDefaultValue()
    {
        var serivce = new SettingsService(contex);
        var definitions = serivce.GetSettingDefinitions();

        var result = serivce.GetSettings();

        foreach (var definition in definitions)
        {
            Assert.Equal(definition.DefaultValue, result.Single(x => x.Key == definition.Key).Value);
        }
    }

    [Fact]
    public async Task GetSettings_WhenSettingDoesExists_ShouldReturnSettingWithValueFromDatabase()
    {
        var serivce = new SettingsService(contex);
        contex.Settings.Add(new Domain.Setting
        {
            Key = "TNBase.Title",
            Value = "TestValue"
        });
        await contex.SaveChangesAsync();

        var result = serivce.GetSettings();

        Assert.Equal("TestValue", result.Single(x => x.Key == "TNBase.Title").Value);
    }
}
