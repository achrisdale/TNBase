using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNBase.Domain;

namespace TNBase.App.Settings;

/// <summary>
/// Service providing retrieval and storage options for application settings stored within the database.
/// </summary>
public class SettingsService : ISettingsService
{
    private readonly ITNBaseContext context;
    private readonly ISettingDefinitionProvider settingDefinitionProvider;

    private static readonly Dictionary<string, List<Action<string>>> bindings = new Dictionary<string, List<Action<string>>>();

    public SettingsService(ITNBaseContext context, ISettingDefinitionProvider settingDefinitionProvider)
    {
        this.context = context;
        this.settingDefinitionProvider = settingDefinitionProvider;
    }

    /// <summary>
    /// Gets the list of all Settings and their definitions available. It doesn't return setting values. Please use GetSettings() function for that.
    /// </summary>
    public List<SettingDefinition> GetSettingDefinitions() => settingDefinitionProvider.GetSettingDefinitions();

    /// <summary>
    /// Returns values of all defined settings. If value is not set in the database the default value is returned.
    /// </summary>
    /// <returns>List of Settins</returns>
    public List<Setting> GetSettings()
    {
        var settings = context.Settings.ToList();
        return GetSettingDefinitions().Select(x => new Setting { Key = x.Key, Value = settings.SingleOrDefault(s => s.Key == x.Key)?.Value ?? x.DefaultValue }).ToList();
    }

    /// <summary>
    /// Return setting value of given setting definition. If value is not set in the database the default value is returned.
    /// </summary>
    /// <param name="definition">Setting Definition</param>
    /// <returns>Value of the setting</returns>
    public string GetSetting(SettingDefinition definition)
    {
        return GetSetting(definition.Key);
    }

    /// <summary>
    /// Return setting value of given setting key. If value is not set in the database the default value is returned.
    /// </summary>
    /// <param name="key">Setting Key</param>
    /// <returns>Value of the setting</returns>
    public string GetSetting(string key)
    {
        var setting = context.Settings.SingleOrDefault(s => s.Key == key);
        if (setting == null)
        {
            var definition = GetSettingDefinitions().SingleOrDefault(x => x.Key == key);
            return definition?.DefaultValue ?? string.Empty;
        }
        return setting.Value;
    }

    /// <summary>
    /// Stored setting value to the database by a given key.
    /// </summary>
    /// <param name="setting">Setting object with key and value</param>
    /// <returns>Task</returns>
    public async Task SetSetting(Setting setting)
    {
        var existingSetting = context.Settings.FirstOrDefault(x => x.Key == setting.Key);

        if (existingSetting != null)
        {
            existingSetting.Value = setting.Value;
        }
        else
        {
            context.Settings.Add(setting);
        }

        await context.SaveChangesAsync();

        if (bindings.ContainsKey(setting.Key))
        {
            foreach (var binding in bindings[setting.Key])
            {
                binding.Invoke(setting.Value);
            }
        }
    }

    /// <summary>
    /// Sets action predecate that gets called initially and then every time the setting with the given key is updated.
    /// </summary>
    /// <param name="definition">Setting Definition</param>
    /// <param name="valuePredicate">Action Predicate</param>
    public void GetAndBind(SettingDefinition definition, Action<string> valuePredicate)
    {
        GetAndBind(definition.Key, valuePredicate);
    }

    /// <summary>
    /// Sets action predecate that gets called initially and then every time the setting with the given key is updated.
    /// </summary>
    /// <param name="key">Setting Key</param>
    /// <param name="valuePredicate">Action Predicate</param>
    public void GetAndBind(string key, Action<string> valuePredicate)
    {
        if (!bindings.ContainsKey(key))
        {
            bindings.Add(key, new List<Action<string>>());
        }

        bindings[key].Add(valuePredicate);
        valuePredicate(GetSetting(key));
    }

    /// <summary>
    /// Upade all bound settings
    /// </summary>
    public void RefreshAll()
    {
        var settings = GetSettings();
        foreach (var binding in bindings)
        {
            var setting = GetSetting(binding.Key);
            foreach (var action in binding.Value)
            {
                action.Invoke(setting);
            }
        }
    }
}

