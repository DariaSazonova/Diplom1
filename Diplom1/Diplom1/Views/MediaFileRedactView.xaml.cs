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
    public partial class MediaFileRedactView : ContentPage
    {
        private MediaFileRedactViewModel vm = new();
        public MediaFileRedactView(MediaPageModel mediaFile)
        {
            InitializeComponent();
            if (mediaFile != null)
            {
                UpdateButton.IsVisible = true;
                AddButton.IsVisible = false;
                vm.model = mediaFile;
            }
            else
            {
                UpdateButton.IsVisible = false;
                AddButton.IsVisible = true;
            }
            BindingContext = vm;
        }

        private async void Button_ClickedUpdate(object sender, EventArgs e)
        {
            var res = await vm.update.Update(vm);
            if (res)
            {
                await DisplayAlert("Сообщение", "Данные успешно обновлены", "ОК");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Сообщение", "Ошибка. Не удалось изменить", "ОК");
            }
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            var res = await vm.update.Add(vm);
            if (res)
            {
                await DisplayAlert("Сообщение", "Данные успешно обновлены", "ОК");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Сообщение", "Ошибка. Не удалось изменить", "ОК");
            }
        }
    }
}