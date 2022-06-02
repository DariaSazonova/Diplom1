using Diplom1.Toast;
using Diplom1.ViewModels;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplom1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoCollegeView : ContentPage
    {
        public InfoColledgeViewModel viewModel = new();
        public InfoCollegeView()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
        private void VideoPriem_Navigated(object sender, WebNavigatedEventArgs e)
        {
            viewModel.Indicator = false;
        }

        private void VideoPriem_Navigating(object sender, WebNavigatingEventArgs e)
        {
            viewModel.Indicator = true;
        }

        private async void Button_ClickedTelegram(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://t.me/ukit_college");
        }

        private async void Button_ClickedInstagram(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://vk.com/mgutu");
        }
        private async void Button_ClickedAdress(object sender, EventArgs e)
        {
            if(await CheckAndAskPermission<Permissions.LocationWhenInUse>())
            {
                var geo = CrossGeolocator.Current;
                if(geo.IsGeolocationEnabled)
                    await Navigation.PushAsync(new MapView());
                else
                {
                    Application.Current.MainPage.Toast("Включите геоданные", status.warning);
                }
            }
            else
            {
                await CheckAndAskPermission<Permissions.LocationWhenInUse>();
            }
        }
        private async Task<bool> CheckAndAskPermission<T>() where T : Permissions.BasePermission, new()
        {
            var status = await Permissions.CheckStatusAsync<T>();
            if (status == PermissionStatus.Granted) return true;
            status = await Permissions.RequestAsync<T>();
            var hasPermission = status == PermissionStatus.Granted;
            return hasPermission;
        }
    }
}