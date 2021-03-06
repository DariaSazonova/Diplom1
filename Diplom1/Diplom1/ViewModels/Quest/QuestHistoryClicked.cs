using Diplom1.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Diplom1.ViewModels.Quest
{
    public class QuestHistoryClicked : ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }
        private readonly QuestFirstViewModel vm;
        public QuestHistoryClicked(QuestFirstViewModel viewModel)
        {
            vm = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            vm.IndicatorIsVisible = true;
            await System.Threading.Tasks.Task.Delay(500);
            int userId = Convert.ToInt32(PreferencesApp.UserID);
            Application.Current.MainPage = new Diplom1.Views.AbbRating(0, userId);
            //await Application.Current.MainPage.Navigation.PushAsync(new Diplom1.Views.AbbRating(0, userId));
            vm.IndicatorIsVisible = false;
        }
    }
}