using Diplom1.Client;
using Diplom1.Views;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Diplom1.ViewModels
{
    public class LogOutUser:ICommand
    {
        public static string Error = "Повторите еще раз, ошибка на телефоне";

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            bool succLogOut = await Application.Current.MainPage.DisplayAlert("Предупреждение", "Выполнить выход?", "да", "нет");
            if (succLogOut)
            {
                Preferences.Clear();
                Application.Current.MainPage = new NavigationPage(new AvtorizationPage());
            }
            
        }
    }
}
