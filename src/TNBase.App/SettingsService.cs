using System.Collections.Generic;
using System.Linq;
using TNBase.Domain;

namespace TNBase.App;

/// <summary>
/// Service providing retrieval and storage options for application settings stored within the database.
/// </summary>
public class SettingsService : ISettingsService
{
    /// <summary>
    /// Gets the list of all Settings and their definitions available. It doesn't return setting values. Please use GetSettings() function for that.
    /// </summary>
    public List<SettingDefinition> GetSettingDefinitions() => typeof(SettingDefinitions).GetProperties().Select(x => (SettingDefinition)x.GetValue(null)).ToList();

    public List<Setting> GetSettings()
    {
        return new List<Setting>
        {
            new Setting(){ Key= "TNBase.Title", Value = "My new TNBase"}
        };
    }
}
