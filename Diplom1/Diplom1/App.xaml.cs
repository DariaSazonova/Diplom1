
using Diplom1.Client;
using Diplom1.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplom1
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            NavigationAsync();
            //MainPage = new NavigationPage(new MapView());
        }
        private  void NavigationAsync()
        {
            bool current = PreferencesApp.findLogin() && PreferencesApp.findPassword() && PreferencesApp.findUserID();
            if (current)
            {
                MainPage = new HomePage();
            }
            else MainPage = new AvtorizationPage();
        }
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
