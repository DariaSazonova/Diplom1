using Diplom1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Diplom1.ViewModels.AvtorizationViewModel
{
    public  class RegistrationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public RegistationModel model { get; set; } = new();
        public Registration registrationClicked; 
        public RegistrationViewModel()
        {
            registrationClicked = new();
        }
        public string Login
        {
            get
            {
                return model.Login;
            }
            set
            {
                if (model.Login != value)
                {
                    model.Login = value;
                    OnPropertyChanged("Login");
                }
            }
        }
        public string Password
        {
            get
            {
                return model.Password;
            }
            set
            {
                if (model.Password != value)
                {
                    model.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        public string PasswordAgain
        {
            get
            {
                return model.PasswordAgain;
            }
            set
            {
                if (model.PasswordAgain != value)
                {
                    model.PasswordAgain = value;
                    OnPropertyChanged("PasswordAgain");
                }
            }
        }
        public int IdApplicants
        {
            get
            {
                return model.IdApplicants;
            }
            set
            {
                if (model.IdApplicants != value)
                {
                    model.IdApplicants = value;
                    OnPropertyChanged("IdApplicants");
                }
            }
        }
        public string Surname
        {
            get
            {
                return model.Surname;
            }
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
            get
            {
                return model.Name;
            }
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
            get
            {
                return model.Patronymic;
            }
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
            get
            {
                return model.Phone;
            }
            set
            {
                if (model.Phone != value)
                {
                    model.Phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }
        public string Email
        {
            get
            {
                return model.Email;
            }
            set
            {
                if (model.Email != value)
                {
                    model.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string DateOfBirth
        {
            get
            {
                return model.DateOfBirth;
            }
            set
            {
                if (model.DateOfBirth != value)
                {
                    model.DateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }
        public bool IndicatorIsVisible
        {
            get { return model.IndicatorIsVisible; }
            set
            {
                if (model.IndicatorIsVisible != value)
                {
                    model.IndicatorIsVisible = value;
                    OnPropertyChanged("IndicatorIsVisible");
                }
            }
        }
        public bool ButtonEnabled
        {
            get { return model.ButtonEnabled; }
            set
            {
                if (model.ButtonEnabled != value)
                {
                    model.ButtonEnabled = value;
                    OnPropertyChanged("ButtonEnabled");
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
