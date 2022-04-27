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
    public partial class MediaFilesAdminView : ContentPage
    {
        private readonly MediaPageViewModel vm = new();
        private int IsNavigating = 0;
        public MediaFilesAdminView()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            IsNavigating = 0;
            vm.model = await vm.getMediaFiles.get();
            ListMedia.ItemsSource = vm.model;
            ListMedia.BindingContext = vm.model;
        }
        private void VideoPriem_Navigated(object sender, WebNavigatedEventArgs e)
        {
            IsNavigating = 1;
            Indicator.IsVisible = false;
        }

        private void VideoPriem_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if(IsNavigating==0)
                Indicator.IsVisible = true;
        }

        private void ListMedia_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListMedia.SelectedItem = null;
        }

        private async void ToolbarItem_ClickedAddNew(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MediaFileRedactView(null));
        }

        private async void ListMedia_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MediaPageModel;
            if (item != null)
                await Navigation.PushAsync(new MediaFileRedactView(item));
        }

        private async void Button_ClickedRemove(object sender, EventArgs e)
        {
            Indicator.IsVisible = true;
            var id = (sender as ImageButton).AutomationId;
            var res = await vm.update.Remove(id);
            if (res)
            {
                vm.model = await vm.getMediaFiles.get();
                ListMedia.ItemsSource = vm.model;
                ListMedia.BindingContext = vm.model;
            }
            else
            {
                Indicator.IsVisible = false;
                await DisplayAlert("Сообщение", "Ошибка сервера", "ОК");
            }
            Indicator.IsVisible = false;
        }

        private void ToolbarItem_ClickedBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new HomePage());
        }
    }
}