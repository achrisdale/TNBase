using System.Collections.Generic;
using TNBase.Domain;

namespace TNBase.App
{
    public interface ISettingsService
    {
        List<SettingDefinition> GetSettingDefinitions();

        List<Setting> GetSettings();
    }
}