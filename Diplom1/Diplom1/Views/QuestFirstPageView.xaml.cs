using Diplom1.ViewModels.Quest;
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
    public partial class QuestFirstPageView : ContentPage
    {
        
        public QuestFirstPageView()
        {
            InitializeComponent();
            Indicator.IsVisible = false;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Indicator.IsVisible = false;
        }

        private async void Button_ClickedLevel1(object sender, EventArgs e)
        {
            Indicator.IsVisible = true;
            await Task.Delay(1000);
            await Navigation.PushAsync(new QuestView(1));
        }

        private async void Button_ClickedLevel2(object sender, EventArgs e)
        {
            Indicator.IsVisible = true;
            await Navigation.PushAsync(new QuestView(2));
        }

        private async void Button_ClickedLevel3(object sender, EventArgs e)
        {
            Indicator.IsVisible = true;
            await Navigation.PushAsync(new QuestView(3));
        }
    }
}