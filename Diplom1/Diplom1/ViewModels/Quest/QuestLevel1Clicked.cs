using Diplom1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Diplom1.ViewModels.Quest
{
    public class QuestLevel1Clicked : ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }
        private readonly QuestFirstViewModel vm;
        public QuestLevel1Clicked(QuestFirstViewModel viewModel)
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
            Application.Current.MainPage = new Diplom1.Views.HomePage("level1");
            //await Application.Current.MainPage.Navigation.PushAsync(new Diplom1.Views.HomePage("level1"));
            vm.IndicatorIsVisible = false;
        }
    }
}
