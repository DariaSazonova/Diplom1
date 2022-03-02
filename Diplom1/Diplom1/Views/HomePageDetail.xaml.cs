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
    public partial class HomePageDetail : ContentPage
    {
        public HomePageDetail()
        {
            InitializeComponent();
        }

        private async void Button_ClickedInfo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SpecialityInformation());
        }

        private async void Button_ClickedQuest(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuestFirstPageView());
        }

        private async void Button_ClickedCollegeInfo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoCollegeView());
        }
    }
    
}