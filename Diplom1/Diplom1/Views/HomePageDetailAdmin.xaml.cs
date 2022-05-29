using Diplom1.Client;
using Diplom1.Toast;
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            viewModel.Indicator = true;
            GetSpicialityInformation getSpicialityInformation = new();
            var list = await getSpicialityInformation.get("SpecialityInformation");
            if (list != null)
            {
                await Navigation.PushAsync(new SpecialityInformation(list));
            }
            else
            {
                Application.Current.MainPage.Toast(getSpicialityInformation.error, status.error);
            }
            viewModel.Indicator = false;
        }
    }
}