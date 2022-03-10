using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplom1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageDetailAdmin : ContentPage
    {
        public HomePageDetailAdmin()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Indicator.IsVisible = false;
        }
        private void Button_ClickedLevel1(object sender, EventArgs e)
        {
            Indicator.IsVisible = true;
            Navigation.PushAsync(new AbbRating(1));
            Indicator.IsVisible = true;
        }

        private void Button_ClickedLevel2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AbbRating(2));
        }

        private void Button_ClickedLevel3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AbbRating(3));
        }
    }
}