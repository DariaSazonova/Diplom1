using Diplom1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Diplom1.ViewModels.HomePage
{
    public class InfoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            HomePageDetail homePageDetail = new();
            await homePageDetail.Navigation.PushAsync(new SpecialityInformation());
        }
    }
}
