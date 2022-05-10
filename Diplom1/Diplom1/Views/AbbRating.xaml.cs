using Diplom1.Interfaces;
using Diplom1.Models;
using Diplom1.Toast;
using Diplom1.ViewModels.AbbRating;
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
    public partial class AbbRating : ContentPage
    {
        public AbbRatingViewModel viewModel;
        public AbbRating(int level, int appid=0)
        {
            InitializeComponent();
            viewModel = new(level, appid);
            BindingContext = viewModel;
            if (appid == 0)
            {
                TitleLabel.IsVisible = true;
                TitleLabel.Text = "ОТОБРАЖАЮТСЯ ЛУЧШИЕ РЕЗУЛЬТАТЫ СТУДЕНТОВ";
            }
        }
        private void StudentsRating_Refreshing(object sender, EventArgs e)
        {

        }

        private async void StudentsRating_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as AbbRatingModel;
            if (item != null)
            {
                Diplom1.ViewModels.Quest.GetTestResult GetTestResult = new();
                var res = await GetTestResult.Result(item.idApplicant, item.id);
                if (res != null)
                {
                    contentView.Content = new TestResultView(res);
                    Testresults.IsVisible = true;
                }
                else
                {
                    Testresults.IsVisible = false;
                    Application.Current.MainPage.Toast($"Тест был изменен\nИнформация о результатах недоступна", status.error);
                }
            }
        }

        private async void Close(object sender, EventArgs e)
        {
            Testresults.IsVisible = false;
        }

        private void StudentsRating_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            StudentsRating.SelectedItem = null;
        }

        private void ImageButton_ClickedBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new HomePage();
        }

        private async void PhoneButton_Clicked(object sender, EventArgs e)
        {
            var phone = (sender as ImageButton).AutomationId.ToString();
            await DependencyService.Get<Calls>()?.Call(phone);
        }
    }
}