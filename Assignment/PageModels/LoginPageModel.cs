using System;
using System.Threading.Tasks;
using FreshMvvm;
using MvvmHelpers.Commands;
using PropertyChanged;
using Xamarin.Forms;
using Constants = Assignment.Common.Constants.AppConstants;

namespace Assignment.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginPageModel : BasePageModel
    {
        #region DataModel
        public bool IsSigningIn { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public bool IsEmailAdded { get; set; }
        #endregion

        #region Commands
        public AsyncCommand SignInCommand { get; set; }
        #endregion

        public LoginPageModel()
        {
            SignInCommand = new AsyncCommand(SignInAsync);
        }

        #region Command Methods
        async Task SignInAsync()
        {
            IsSigningIn = true;

            if (EmailId != null && Constants.IsValidEmail(EmailId)
                && !string.IsNullOrEmpty(Password))
            {
                await Task.Delay(3000);
                await NavigateToHomePage();
            }
            else
            {
                IsEmailAdded = false;
                ShowError(Resources.AppResources.MSG_Valid_Mail_Pwd);
            }

            IsSigningIn = false;
        }
        #endregion

        #region Private / Internal methods
        private async Task NavigateToHomePage()
        {
            await CoreMethods.PushPageModel<DashboardPageModel>(typeof(DashboardPageModel), false, false);
            Page page = FreshPageModelResolver.ResolvePageModel<DashboardPageModel>();
            Application.Current.MainPage = new FreshNavigationContainer(page);
        }
        #endregion
    }
}
