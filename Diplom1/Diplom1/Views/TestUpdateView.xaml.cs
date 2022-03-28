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

        private async void ToolbarItem_ClickedSave(object sender, EventArgs e)
        {
            vm.IndicatorIsVisible = true;
            var res = await vm.savetest.Save(vm);
            if (res)
            {
                vm.IndicatorIsVisible = false;
                await DisplayAlert("Сообщение", "тест изменен", "ОК");
            }
            else
            {
                vm.IndicatorIsVisible = false;
                await DisplayAlert("Сообщение", "ошибка. не удалось обновить тест", "ОК");
            }
        }
    }
}