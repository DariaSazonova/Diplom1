using Diplom1.ViewModels;
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
        public HomePageAdminViewModel viewModel = new();
        public HomePageDetailAdmin()
        {
            InitializeComponent();
            ChartContentView.Content = new ChartView();
            BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        //private async void Button_ClickedLevel1(object sender, EventArgs e)
        //{
        //    Indicator.IsVisible = true;
        //    await Navigation.PushAsync(new AbbRating(1));
        //    Indicator.IsVisible = false;
        //}

        //private async void Button_ClickedLevel2(object sender, EventArgs e)
        //{
        //    Indicator.IsVisible = true;
        //    await Navigation.PushAsync(new AbbRating(2));
        //    Indicator.IsVisible = false;
        //}

        //private async void Button_ClickedLevel3(object sender, EventArgs e)
        //{
        //    Indicator.IsVisible = true;
        //    await Navigation.PushAsync(new AbbRating(3));
        //    Indicator.IsVisible = false;
        //}

        //private async void Button_ClickedRedact1(object sender, EventArgs e)
        //{
        //    viewModel.Indicator = true;
        //    await Navigation.PushAsync(new TestUpdateView(1));
        //    viewModel.Indicator = false;
        //}
        //private async void Button_ClickedRedact2(object sender, EventArgs e)
        //{
        //    viewModel.Indicator = true;
        //    await Navigation.PushAsync(new TestUpdateView(2));
        //    viewModel.Indicator = false;
        //}
        //private async void Button_ClickedRedact3(object sender, EventArgs e)
        //{
        //    viewModel.Indicator = true;
        //    await Navigation.PushAsync(new TestUpdateView(3));
        //    viewModel.Indicator = false;
        //}

        //private async void Button_ClickedMedia(object sender, EventArgs e)
        //{
        //    viewModel.Indicator = true;
        //    await Navigation.PushAsync(new MediaFilesAdminView());
        //    viewModel.Indicator = false;
        //}

        //private async void Button_ClickedStatic(object sender, EventArgs e)
        //{
        //    viewModel.Indicator = true;
        //    await Navigation.PushAsync(new ChartView());
        //    viewModel.Indicator = false;
        //}
    }
}