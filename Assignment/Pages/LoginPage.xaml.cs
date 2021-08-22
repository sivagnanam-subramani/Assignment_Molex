using System;
using System.Collections.Generic;
using Assignment.Common.Themes;
using Xamarin.Forms;
using Enums = Assignment.Common.Constants;

namespace Assignment.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            ThemeSwitch.IsToggled = ThemeLoader.CurrentTheme() == Enums.Themes.Dark ? true : false;
        }

        void Switch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {

            if (e.Value == true)
            {
                ThemeLoader.ChangeTheme(Common.Constants.Themes.Dark);
            }
            else
            {
                ThemeLoader.ChangeTheme(Common.Constants.Themes.Light);
            }
        }
    }
}
