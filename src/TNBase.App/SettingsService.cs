using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNBase.Domain;

namespace TNBase.App;

/// <summary>
/// Service providing retrieval and storage options for application settings stored within the database.
/// </summary>
public class SettingsService : ISettingsService
{
    private readonly ITNBaseContext context;

    public SettingsService(ITNBaseContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Gets the list of all Settings and their definitions available. It doesn't return setting values. Please use GetSettings() function for that.
    /// </summary>
    public List<SettingDefinition> GetSettingDefinitions() => typeof(SettingDefinitions).GetProperties().Select(x => (SettingDefinition)x.GetValue(null)).ToList();

    public List<Setting> GetSettings()
    {
        var settings = context.Settings.ToList();
        return GetSettingDefinitions().Select(x => new Setting { Key = x.Key, Value = settings.SingleOrDefault(s => s.Key == x.Key)?.Value ?? x.DefaultValue }).ToList();
    }

    public async Task SetSetting(Setting setting)
    {

    }
}
