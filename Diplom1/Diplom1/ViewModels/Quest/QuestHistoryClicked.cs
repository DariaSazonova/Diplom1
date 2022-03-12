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
            vm.IndicatorVisibility = true;
            Application.Current.MainPage = new Diplom1.Views.HomePage("history");
            vm.IndicatorVisibility = false;
        }
    }
}