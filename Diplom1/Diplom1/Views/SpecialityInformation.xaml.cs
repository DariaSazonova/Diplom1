using Diplom1.Client;
using Diplom1.Models;
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
    public partial class SpecialityInformation : ContentPage
    {
        private SpecialityInformationViewModel viewModel;
        public SpecialityInformation(List<MediaPageModel> list)
        {
            InitializeComponent();
            viewModel = new(list);
            BindingContext = viewModel;
            ToolbarItem.IconImageSource = PreferencesApp.role == "Абитуриент" ? "" : "update.png";
            ToolbarItem.IsEnabled = PreferencesApp.role == "Абитуриент" ? false : true;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await FadeAnimateY(UniversityName);
            await FadeAnimateY(StudentInmage);
            await FadeAnimateY(SpecialityName);
            await FadeAnimateY(YearsLabel);
            await FadeAnimateY(KvalInfo);
            await FadeAnimateY(ProfInfo);
            await FadeAnimateY(CostInfo);
        }
        private static async Task FadeAnimateY(View view)
        {
            await Task.WhenAll
               (
                    view.FadeTo(1, 350),
                    view.TranslateTo(0, 0, 350)
               );
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            viewModel.Indicator = true;
            await viewModel.Update();
            viewModel.Indicator = false;
        }
    }
}