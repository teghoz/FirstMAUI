using System.ComponentModel;
using System.Globalization;
using FirstMaui.Resources.Translation;

namespace FirstMaui.Resources.Translations;

public class LocalizationResourceManager : INotifyPropertyChanged
{
    /// <summary>
    /// Usage: Title = "{Binding MyCodeBehindLocalizationResourceManager[MainPageTitle], Mode=OneWay}"
    /// where MyCodeBehindLocalizationResourceManager is a code-behind property with value LocalizationResourceManager.Instance
    /// So here the Title value is binding to the resource value
    /// Each time we call the method LocalizationResourceManager.SetCulture, our property value is updated.
    /// </summary>
    private LocalizationResourceManager()
    {
        CashBoxTranslations.Culture = CultureInfo.CurrentCulture;
    }

    public static LocalizationResourceManager Instance { get; } = new();

    public object this[string resourceKey] =>
        CashBoxTranslations.ResourceManager.GetObject(resourceKey, CashBoxTranslations.Culture) ?? Array.Empty<byte>();

    public static string Translate(string text)
    {
        var translation = CashBoxTranslations.ResourceManager.GetString(text, CashBoxTranslations.Culture);
        if (translation == null)
        {
            translation = text;
        }
        return translation;
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    public void SetCulture(CultureInfo culture)
    {
        CashBoxTranslations.Culture = culture;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
}
