using System;
using Plugin.Settings;
using Xamarin.Forms;
using Enums = Assignment.Common.Constants;

namespace Assignment.Common.Themes
{
    public class ThemeLoader
    {
        public static void ChangeTheme(Enums.Themes theme)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                CrossSettings.Current.AddOrUpdateValue("SelectedTheme", (int)theme);

                switch (theme)
                {
                    case Enums.Themes.Light:
                        {
                            mergedDictionaries.Add(new LightTheme());
                            break;
                        }
                    case Enums.Themes.Dark:
                        {
                            mergedDictionaries.Add(new DarkTheme());
                            break;
                        }
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }


        public static void LoadTheme()
        {
            Enums.Themes currentTheme = CurrentTheme();
            ChangeTheme(currentTheme);
        }


        public static Enums.Themes CurrentTheme()
        {
            return (Enums.Themes)CrossSettings.Current.GetValueOrDefault("SelectedTheme", (int)Enums.Themes.Light);
        }
    }
}

