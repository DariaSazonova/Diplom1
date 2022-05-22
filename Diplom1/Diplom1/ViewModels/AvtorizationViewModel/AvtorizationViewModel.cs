using Diplom1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Diplom1.ViewModels.AvtorizationViewModel
{
    public class AvtorizationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SignIn { protected set; get; }
        public UserModel model;
        public bool button = false;
        public AvtorizationViewModel()
        {
            model = new();
            SignIn = new SignIn(this);
        }
        public bool IndicatorIsVisible
        {
            get { return model.Indicator; }
            set
            {
                if (model.Indicator != value)
                {
                    model.Indicator = value;
                    OnPropertyChanged("IndicatorIsVisible");
                }
            }
        }
        public bool IsButtonEnabled
        {
            get { return button; }
            set
            {
                if (button != value)
                {
                    button = value;
                    OnPropertyChanged("IsButtonEnabled");
                }
            }
        }
        
        public string Email
        {
            get { return model.Login; }
            set
            {
                if (model.Login != value)
                {
                    model.Login = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Password
        {
            get { return model.Password; }
            set
            {
                if (model.Password != value)
                {
                    model.Password = value;
                    OnPropertyChanged("Password");
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
