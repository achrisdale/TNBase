using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNBase.Domain;

namespace TNBase.App.Settings
{
    /// <summary>
    /// Service providing retrieval and storage options for application settings stored within the database.
    /// </summary>
    public interface ISettingsService
    {
        /// <summary>
        /// Gets the list of all Settings and their definitions available. It doesn't return setting values. Please use GetSettings() function for that.
        /// </summary>
        List<SettingDefinition> GetSettingDefinitions();

        /// <summary>
        /// Returns values of all defined settings. If value is not set in the database the default value is returned.
        /// </summary>
        /// <returns>List of Settins</returns>
        List<Setting> GetSettings();

        /// <summary>
        /// Return setting value of given setting definition. If value is not set in the database the default value is returned.
        /// </summary>
        /// <param name="definition">Setting Definition</param>
        /// <returns>Value of the setting</returns>
        string GetSetting(SettingDefinition definition);

        /// <summary>
        /// Return setting value of given setting key. If value is not set in the database the default value is returned.
        /// </summary>
        /// <param name="key">Setting Key</param>
        /// <returns>Value of the setting</returns>
        string GetSetting(string key);

        /// <summary>
        /// Stored setting value to the database by a given key.
        /// </summary>
        /// <param name="setting">Setting object with key and value</param>
        /// <returns>Task</returns>
        Task SetSetting(Setting setting);

        /// <summary>
        /// Sets action predecate that gets called initially and then every time the setting with the given key is updated.
        /// </summary>
        /// <param name="definition">Setting Definition</param>
        /// <param name="valuePredicate">Action Predicate</param>
        void GetAndBind(SettingDefinition definition, Action<string> valuePredicate);

        /// <summary>
        /// Sets action predecate that gets called initially and then every time the setting with the given key is updated.
        /// </summary>
        /// <param name="key">Setting Key</param>
        /// <param name="valuePredicate">Action Predicate</param>
        void GetAndBind(string key, Action<string> valuePredicate);
    }
}