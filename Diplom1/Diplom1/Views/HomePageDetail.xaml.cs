using Diplom1.Client;
using Diplom1.Models;
using Diplom1.Toast;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplom1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageDetail : ContentPage
    {
        public HomePageDetail()
        {
            InitializeComponent();
        }

        private async void Button_ClickedInfo(object sender, EventArgs e)
        {
            Indicator.IsVisible = true;
            GetSpicialityInformation GetSpicialityInformation = new();
            var list = await GetSpicialityInformation.get();
            await Navigation.PushAsync(new SpecialityInformation(list));
            Indicator.IsVisible = false;
        }

        private async void Button_ClickedQuest(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuestFirstPageView());
        }

        private async void Button_ClickedCollegeInfo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoCollegeView());
        }

        private async void Button_ClickedMedia(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MediaPageView());
        }
        
    }
    
}