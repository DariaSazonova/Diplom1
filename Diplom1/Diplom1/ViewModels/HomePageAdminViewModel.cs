using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Diplom1.ViewModels
{
    public class HomePageAdminViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IndicatorIsVisible { get; set; } = false;
        public ICommand Rating1 { protected set; get; }
        public ICommand Rating2 { protected set; get; }
        public ICommand Rating3 { protected set; get; }
        public ICommand TestRedact1 { protected set; get; }
        public ICommand TestRedact2 { protected set; get; }
        public ICommand TestRedact3 { protected set; get; }
        public ICommand Media { protected set; get; }
        public HomePageAdminViewModel()
        {
            Rating1 = new Rating1(this);
            Rating2 = new Rating2(this);
            Rating3 = new Rating3(this);
            TestRedact1 = new TestRedact1(this);
            TestRedact2 = new TestRedact2(this);
            TestRedact3 = new TestRedact3(this);
            Media = new Media(this);
        }
        public bool Indicator
        {
            get { return IndicatorIsVisible; }
            set
            {
                if (IndicatorIsVisible != value)
                {
                    IndicatorIsVisible = value;
                    OnPropertyChanged("Indicator");
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
    public class Rating1 : ICommand
    {
        public event EventHandler CanExecuteChanged;
        HomePageAdminViewModel viewModel;
        public Rating1(HomePageAdminViewModel vm)
        {
            viewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            viewModel.Indicator = true;
            Application.Current.MainPage = new NavigationPage(new Views.AbbRating(1));
            viewModel.Indicator = false;
        }
    }
    public class Rating2 : ICommand
    {
        public event EventHandler CanExecuteChanged;
        HomePageAdminViewModel viewModel;
        public Rating2(HomePageAdminViewModel vm)
        {
            viewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            viewModel.Indicator = true;
            Application.Current.MainPage = new NavigationPage(new Views.AbbRating(2));
            viewModel.Indicator = false;
        }
    }
    public class Rating3 : ICommand
    {
        public event EventHandler CanExecuteChanged;
        HomePageAdminViewModel viewModel;
        public Rating3(HomePageAdminViewModel vm)
        {
            viewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            viewModel.Indicator = true;
            Application.Current.MainPage = new NavigationPage(new Views.AbbRating(3));
            viewModel.Indicator = false;
        }
    }
    public class Media : ICommand
    {
        public event EventHandler CanExecuteChanged;
        HomePageAdminViewModel viewModel;
        public Media(HomePageAdminViewModel vm)
        {
            viewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            viewModel.Indicator = true;
            Application.Current.MainPage = new NavigationPage(new Views.MediaFilesAdminView());
            viewModel.Indicator = false;
        }
    }
    public class TestRedact3 : ICommand
    {
        public event EventHandler CanExecuteChanged;
        HomePageAdminViewModel viewModel;
        public TestRedact3(HomePageAdminViewModel vm)
        {
            viewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            viewModel.Indicator = true;
            Application.Current.MainPage = new NavigationPage(new Views.TestUpdateView(3));
            viewModel.Indicator = false;
        }
    }
    public class TestRedact2 : ICommand
    {
        public event EventHandler CanExecuteChanged;
        HomePageAdminViewModel viewModel;
        public TestRedact2(HomePageAdminViewModel vm)
        {
            viewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            viewModel.Indicator = true;
            Application.Current.MainPage = new NavigationPage(new Views.TestUpdateView(2));
            viewModel.Indicator = false;
        }
    }
    public class TestRedact1 : ICommand
    {
        public event EventHandler CanExecuteChanged;
        HomePageAdminViewModel viewModel;
        public TestRedact1(HomePageAdminViewModel vm)
        {
            viewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            viewModel.Indicator = true;
            Application.Current.MainPage = new NavigationPage(new Views.TestUpdateView(1));
            viewModel.Indicator = false;
        }
    }
}
