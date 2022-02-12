using Diplom1.Client;
using Diplom1.Models;
using Diplom1.ViewModels.HomePage;
using Diplom1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Diplom1.ViewModels
{
    public  class HomePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public UserModel model = new();
        public ICommand exitButton { set; get; }
        public ICommand infoButton { set; get; }
        public HomePageViewModel()
        {
            DateOfBirth = PreferencesApp.DateOfBirth;
            Surname = PreferencesApp.Surname;
            Name = PreferencesApp.Name;
            Patronymic = PreferencesApp.Patronymic;
            Phone = PreferencesApp.Phone;
            role = PreferencesApp.role;

            exitButton = new LogOutUser();
            infoButton = new InfoCommand();
        }
        public string DateOfBirth
        {
            get { return model.DateOfBirth; }
            set
            {
                if (model.DateOfBirth != value)
                {
                    model.DateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }
        public string Surname
        {
            get { return model.Surname; }
            set
            {
                if (model.Surname != value)
                {
                    model.Surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }
        public string Name
        {
            get { return model.Name; }
            set
            {
                if (model.Name != value)
                {
                    model.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Patronymic
        {
            get { return model.Patronymic; }
            set
            {
                if (model.Patronymic != value)
                {
                    model.Patronymic = value;
                    OnPropertyChanged("Patronymic");
                }
            }
        }
        public string Phone
        {
            get { return model.Phone; }
            set
            {
                if (model.Phone != value)
                {
                    model.Phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }
        public string role
        {
            get { return model.role; }
            set
            {
                if (model.role != value)
                {
                    model.role = value;
                    OnPropertyChanged("role");
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
