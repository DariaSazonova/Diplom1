using Diplom1.Models;
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
    public partial class TestUpdateView : ContentPage
    {
        public TestUpdateViewModel vm;
        public TestUpdateView(int level)
        {
            InitializeComponent();
            vm = new(level);
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListTest.ItemsSource = null;
            ListTest.BindingContext = null;
            ListTest.ItemsSource = vm.listQuestions;
            ListTest.BindingContext = vm.listQuestions;
        }

        private async void ToolbarItem_ClickedAdd(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TextQuestionRedact(null, vm));
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Questions;
            var id = e.ItemIndex;
            if (item != null)
                await Navigation.PushAsync(new TextQuestionRedact(item, vm));
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListTest.SelectedItem = null;
        }

        private void ListView_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }

        private async void ImageButton_ClickedDelete(object sender, EventArgs e)
        {
            var item = sender as ImageButton;
            var id = Convert.ToInt32(item.AutomationId);
            vm.listQuestions.RemoveAt(id);
            var res = await vm.savetest.Save(vm);
            if (!res)
                Application.Current.MainPage.Toast("Не получилось удалить вопрос", status.error);
            else
                Application.Current.MainPage.Toast("Вопрос удален", status.message);
            ListTest.ItemsSource = null;
            ListTest.BindingContext = null;
            ListTest.ItemsSource = vm.listQuestions;
            ListTest.BindingContext = vm.listQuestions;
        }
        private void ToolbarItem_ClickedBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new HomePage());
        }
    }
}