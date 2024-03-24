using System.Collections.Generic;
using System.Linq;

namespace TNBase.App.Settings;

public interface ISettingDefinitionProvider
{
    List<SettingDefinition> GetSettingDefinitions();
}

public class SettingDefinitionProvider : ISettingDefinitionProvider
{
    public List<SettingDefinition> GetSettingDefinitions() => typeof(Settings).GetProperties().Select(x => (SettingDefinition)x.GetValue(null)).ToList();
}
