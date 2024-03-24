namespace TNBase.App.Settings;

/// <summary>
/// Setting Type defining how to interpret the value that is stored in the database.
/// </summary>
public enum SettingType
{
    /// <summary>
    /// Free form text field. Type options: Required - must contain value.
    /// </summary>
    Text,

    /// <summary>
    /// Image.
    /// </summary>
    Image
}

/// <summary>
/// Setting Definition.
/// </summary>
/// <param name="Key">Unique identifier of the setting.</param>
/// <param name="Name">Name of the setting.</param>
/// <param name="Description">Helpful description of the setting.</param>
/// <param name="Category">Name of the category that setting belongs to.</param>
/// <param name="Type">Setting type defining how to interpret the value tha is stored in the database.</param>
/// <param name="TypeOptions">Additional type options separated by semicolon ';'.</param>
/// <param name="Order">Order in which this setting should appear within the category</param>
/// <param name="DefaultValue">Default value to be used when one is not set within the database</param>
public record SettingDefinition(string Key, string Name, string Description, string Category, SettingType Type, string TypeOptions = null, int Order = 0, string DefaultValue = null);

/// <summary>
/// Defines all available settings for the application stored within the database.
/// Please add new settings here.
/// </summary>
public static class Settings
{
    public static SettingDefinition AssociationName => new(Key: "Association.Name", Name: "TNBase Title", Description: "Title shown on the main page of the application.", Category: "General", SettingType.Text, TypeOptions: "Required", Order: 0, DefaultValue: "Solihull Borough Talking Newspaper Association");
    public static SettingDefinition AssociationLogo => new(Key: "Association.Logo", Name: "TNBase Logo", Description: "Image shown on the main page of the application.", Category: "General", SettingType.Image, Order: 1, DefaultValue: Images.DefaultLogo);
}
