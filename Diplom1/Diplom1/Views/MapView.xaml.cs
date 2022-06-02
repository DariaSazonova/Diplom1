using Diplom1.Toast;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Diplom1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapView : ContentPage
    {
        private double Latitude = 55.750796;
        private double Longitude = 37.668968;
        public MapView()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await GetCurrentLocaton();
        }
        private async Task GetCurrentLocaton()
        {
            var geo = CrossGeolocator.Current;
            if (geo.IsGeolocationAvailable)
            {
                if (geo.IsGeolocationEnabled)
                {
                //    var current = await geo.GetLastKnownLocationAsync();
                //    if (current != null)
                //    {
                        Position position = new Position(Latitude, Longitude);
                        MapSpan mapSpan = new MapSpan(position, 0.1, 0.1);
                        map.MoveToRegion(mapSpan);
                    //}
                    Pin pin = new Pin
                    {
                        Label = "Университетский колледж информационных технологий",
                        Address = "г.Москва Костомаровская набережная 29",
                        Type = PinType.Place,
                        Position = new Position(Latitude, Longitude)
                    };
                    map.Pins.Add(pin);
                }
                else
                {
                    Application.Current.MainPage.Toast("Включите геолокацию", status.warning);
                }
            }
            else
            {
                await CheckAndAskForLocationPermission();
            }

        }
        public async Task<bool> CheckAndAskForLocationPermission()
        {
            return await CheckAndAskPermission<Permissions.LocationWhenInUse>();
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