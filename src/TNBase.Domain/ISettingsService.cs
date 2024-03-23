//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace TNBase.Domain;

//public interface ISettingsService
//{
//    List<ISetting> GetSettings(); 
//    ISetting GetSetting<T>(string key);
//    T GetSettingValue<T>(string key);
//    void SaveSetting<T> (Setting<T> setting);
//}

//public interface ISetting
//{
//    public string Key { get; set; }
//    public string Name { get; set; }
//    public string Description { get; set; }
//    public string Category { get; set; }
//    public ISettingValue Value { get; set; }
//}

//public interface ISettingValue
//{

//}

//public class StringSetting
//{
//    public async Task<string> GetValue(string key)
//    {

//    }

//    public async Task SetValue(string key, string value)
//    {

//    }
//}
//public class BoolSetting
//{
//    public async Task<string> GetValue(string key)
//    {

//    }

//    public async Task SetValue(string key, string value)
//    {

//    }
//}
//public class ImageSetting
//{
//    public async Task<string> GetValue(string key)
//    {

//    }

//    public async Task SetValue(string key, string value)
//    {

//    }
//}