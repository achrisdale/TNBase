using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNBase.App.Settings;
using TNBase.Domain;
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
        var settingDefinitionProvider = Substitute.For<ISettingDefinitionProvider>();
        settingDefinitionProvider.GetSettingDefinitions().Returns(new List<SettingDefinition>
        {
            new SettingDefinition("Key1", "Name1", "Description1", "Category1", SettingType.Text),
            new SettingDefinition("Key2", "Name2", "Description2", "Category2", SettingType.Text),
            new SettingDefinition("Key3", "Name3", "Description3", "Category3", SettingType.Text)
        });
        var serivce = new SettingsService(contex, settingDefinitionProvider);

        var result = serivce.GetSettingDefinitions();

        Assert.Equal(3, result.Count);
    }

    [Fact]
    public void GetSettings_ShouldReturnDefinedSettings()
    {
        var settingDefinitionProvider = Substitute.For<ISettingDefinitionProvider>();
        settingDefinitionProvider.GetSettingDefinitions().Returns(new List<SettingDefinition>
        {
            new SettingDefinition("Key1", "Name1", "Description1", "Category1", SettingType.Text),
            new SettingDefinition("Key2", "Name2", "Description2", "Category2", SettingType.Text),
        });
        var serivce = new SettingsService(contex, settingDefinitionProvider);

        var result = serivce.GetSettings();

        Assert.Equal("Key1", result.First().Key);
        Assert.Equal("Key2", result.Last().Key);
    }

    [Fact]
    public void GetSettings_WhenSettingDoesNotExist_ShouldReturnSettingWithDefaultValue()
    {
        var settingDefinitionProvider = Substitute.For<ISettingDefinitionProvider>();
        settingDefinitionProvider.GetSettingDefinitions().Returns(new List<SettingDefinition>
        {
            new SettingDefinition("Key1", "Name1", "Description1", "Category1", SettingType.Text, DefaultValue: "DefaultValue1"),
            new SettingDefinition("Key2", "Name2", "Description2", "Category2", SettingType.Text, DefaultValue: "DefaultValue2"),
        });
        var serivce = new SettingsService(contex, settingDefinitionProvider);

        var result = serivce.GetSettings();

        Assert.Equal("DefaultValue1", result.Single(x => x.Key == "Key1").Value);
        Assert.Equal("DefaultValue2", result.Single(x => x.Key == "Key2").Value);
    }

    [Fact]
    public async Task GetSettings_WhenSettingExists_ShouldReturnSettingWithValueFromDatabase()
    {
        var settingDefinitionProvider = Substitute.For<ISettingDefinitionProvider>();
        settingDefinitionProvider.GetSettingDefinitions().Returns(new List<SettingDefinition>
        {
            new SettingDefinition("Key1", "Name1", "Description1", "Category1", SettingType.Text, DefaultValue: "DefaultValue1"),
            new SettingDefinition("Key2", "Name2", "Description2", "Category2", SettingType.Text, DefaultValue: "DefaultValue2"),
            new SettingDefinition("Key3", "Name3", "Description3", "Category3", SettingType.Text, DefaultValue: "DefaultValue3"),
        });
        var serivce = new SettingsService(contex, settingDefinitionProvider);
        contex.Settings.Add(new Setting
        {
            Key = "Key2",
            Value = "TestValue"
        });
        await contex.SaveChangesAsync();

        var result = serivce.GetSettings();

        Assert.Equal("TestValue", result.Single(x => x.Key == "Key2").Value);

        // Just double-check that other values not messed up
        Assert.Equal("DefaultValue1", result.Single(x => x.Key == "Key1").Value);
        Assert.Equal("DefaultValue3", result.Single(x => x.Key == "Key3").Value);
    }

    [Fact]
    public async Task SetSetting_WhenDoesNotExist_ShouldAddSettingToDatabase()
    {
        var settingDefinitionProvider = Substitute.For<ISettingDefinitionProvider>();
        settingDefinitionProvider.GetSettingDefinitions().Returns(new List<SettingDefinition>
        {
            new SettingDefinition("Key1", "Name1", "Description1", "Category1", SettingType.Text, DefaultValue: "DefaultValue1"),
        });
        var serivce = new SettingsService(contex, settingDefinitionProvider);
        var setting = new Setting
        {
            Key = "Key1",
            Value = "NewValue"
        };
        await serivce.SetSetting(setting);

        var result = contex.Settings.ToList();

        Assert.Single(result);
        Assert.Equal("NewValue", result.Single(x => x.Key == "Key1").Value);
    }

    [Fact]
    public async Task SetSetting_WhenExists_ShouldUpdateSettingToDatabase()
    {
        var settingDefinitionProvider = Substitute.For<ISettingDefinitionProvider>();
        settingDefinitionProvider.GetSettingDefinitions().Returns(new List<SettingDefinition>
        {
            new SettingDefinition("Key1", "Name1", "Description1", "Category1", SettingType.Text, DefaultValue: "DefaultValue1"),
        });
        var serivce = new SettingsService(contex, settingDefinitionProvider);
        contex.Settings.Add(new Setting
        {
            Key = "Key1",
            Value = "ExistingValue"
        });
        await contex.SaveChangesAsync();

        var setting = new Setting
        {
            Key = "Key1",
            Value = "NewValue"
        };
        await serivce.SetSetting(setting);

        var result = contex.Settings.ToList();

        Assert.Single(result);
        Assert.Equal("NewValue", result.Single(x => x.Key == "Key1").Value);
    }

    [Fact]
    public async Task GetSetting_WhenExists_ShouldReturnFromDatabase()
    {
        var settingDefinitionProvider = Substitute.For<ISettingDefinitionProvider>();
        settingDefinitionProvider.GetSettingDefinitions().Returns(new List<SettingDefinition>
        {
            new SettingDefinition("Key1", "Name1", "Description1", "Category1", SettingType.Text, DefaultValue: "DefaultValue1"),
        });
        var serivce = new SettingsService(contex, settingDefinitionProvider);
        contex.Settings.Add(new Setting
        {
            Key = "Key1",
            Value = "ExistingValue"
        });
        await contex.SaveChangesAsync();

        var result = serivce.GetSetting("Key1");

        Assert.Equal("ExistingValue", result);
    }

    [Fact]
    public void GetSetting_WhenDoesNotExist_ShouldReturnDefaultValue()
    {
        var settingDefinitionProvider = Substitute.For<ISettingDefinitionProvider>();
        settingDefinitionProvider.GetSettingDefinitions().Returns(new List<SettingDefinition>
        {
            new SettingDefinition("Key1", "Name1", "Description1", "Category1", SettingType.Text, DefaultValue: "DefaultValue1"),
        });
        var serivce = new SettingsService(contex, settingDefinitionProvider);

        var result = serivce.GetSetting("Key1");

        Assert.Equal("DefaultValue1", result);
    }

    [Fact]
    public void GetSetting_WhenDoesNotExistAndNoDefaultValue_ShouldReturnEmptyString()
    {
        var settingDefinitionProvider = Substitute.For<ISettingDefinitionProvider>();
        settingDefinitionProvider.GetSettingDefinitions().Returns(new List<SettingDefinition>
        {
            new SettingDefinition("Key1", "Name1", "Description1", "Category1", SettingType.Text),
        });
        var serivce = new SettingsService(contex, settingDefinitionProvider);

        var result = serivce.GetSetting("Key1");

        Assert.Equal("", result);
    }

    [Fact]
    public void GetAndBind_WhenBound_ShouldUpdateValue()
    {
        var valueToSet = "OriginalValue";
        var settingDefinitionProvider = Substitute.For<ISettingDefinitionProvider>();
        settingDefinitionProvider.GetSettingDefinitions().Returns(new List<SettingDefinition>
        {
            new SettingDefinition("Key1", "Name1", "Description1", "Category1", SettingType.Text, DefaultValue: "NewValue"),
        });
        var serivce = new SettingsService(contex, settingDefinitionProvider);

        serivce.GetAndBind("Key1", value =>
        {
            valueToSet = value;
        });

        Assert.Equal("NewValue", valueToSet);
    }

    [Fact]
    public async Task GetAndBind_WhenNewValueSet_ShouldUpdateValue()
    {
        var valueToSet = "OriginalValue";
        var settingDefinitionProvider = Substitute.For<ISettingDefinitionProvider>();
        settingDefinitionProvider.GetSettingDefinitions().Returns(new List<SettingDefinition>
        {
            new SettingDefinition("Key1", "Name1", "Description1", "Category1", SettingType.Text, DefaultValue: "DefaultValue1"),
        });
        var serivce = new SettingsService(contex, settingDefinitionProvider);

        serivce.GetAndBind("Key1", value =>
        {
            valueToSet = value;
        });

        await serivce.SetSetting(new Setting { Key = "Key1", Value = "ValueToExpect" });

        Assert.Equal("ValueToExpect", valueToSet);
    }

    [Fact]
    public async Task RefreshAll_ShouldUpdateAllBoundValues()
    {
        var valueToSet1_1 = "OriginalValue1_1";
        var valueToSet1_2 = "OriginalValue1_2";
        var valueToSet2 = "OriginalValue2";

        var settingDefinitionProvider = Substitute.For<ISettingDefinitionProvider>();
        settingDefinitionProvider.GetSettingDefinitions().Returns(new List<SettingDefinition>
        {
            new SettingDefinition("Key1", "Name1", "Description1", "Category1", SettingType.Text, DefaultValue: "DefaultValue1"),
            new SettingDefinition("Key2", "Name2", "Description2", "Category2", SettingType.Text, DefaultValue: "DefaultValue2"),
        });
        var serivce = new SettingsService(contex, settingDefinitionProvider);

        serivce.GetAndBind("Key1", value => valueToSet1_1 = value);
        serivce.GetAndBind("Key1", value => valueToSet1_2 = value);
        serivce.GetAndBind("Key2", value => valueToSet2 = value);

        contex.Settings.Add(new Setting { Key = "Key1", Value = "UpdatedValue1" });
        contex.Settings.Add(new Setting { Key = "Key2", Value = "UpdatedValue2" });
        await contex.SaveChangesAsync();

        serivce.RefreshAll();

        Assert.Equal("UpdatedValue1", valueToSet1_1);
        Assert.Equal("UpdatedValue1", valueToSet1_2);
        Assert.Equal("UpdatedValue2", valueToSet2);
    }
}
