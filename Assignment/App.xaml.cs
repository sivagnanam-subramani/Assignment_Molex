using System;
using Assignment.Common.Themes;
using Assignment.Managers;
using Assignment.Managers.Interaces;
using Assignment.PageModels;
using Assignment.Repository;
using Assignment.Repository.Interfaces;
using Assignment.Services;
using Assignment.Services.Interfaces;
using FreshMvvm;
using FreshTinyIoC;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment
{
    public partial class App : Application
    {
        public static string Branding { get; set; }
        public App()
        {
            Setup(FreshTinyIoCContainer.Current);
            InitializeComponent();
            SetupBranding();
        }

        private void SetupBranding()
        {
            // For branding use below lines and it will reflect
            //throughtout the app images will also change
            //Just for status bar in android need to be set.
            ThemeLoader.LoadTheme();
        }

        private void Setup(FreshTinyIoCContainer current)
        {
            current.Register<IRestService, RestService>();
            current.Register<IStoriesRepository, StoriesRepository>();
            current.Register<IStoriesManager, StoriesManager>();
        }

        protected override void OnStart()
        {
            var basicNavContainer = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<LoginPageModel>());
            MainPage = basicNavContainer;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
