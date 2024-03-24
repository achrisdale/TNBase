using System.Collections.Generic;
using System.Threading.Tasks;
using TNBase.Domain;

namespace TNBase.App
{
    public interface ISettingsService
    {
        List<SettingDefinition> GetSettingDefinitions();

        List<Setting> GetSettings();
        Task SetSetting(Setting setting);
    }
}