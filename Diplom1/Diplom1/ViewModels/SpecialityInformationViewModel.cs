using Diplom1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Diplom1.ViewModels
{
    public class SpecialityInformationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public SpecialityInformationModel model { get; set; } = new();
        public SpecialityInformationViewModel()
        {

        }
        public bool IsNotEdior
        {
            get { return model.isNotEdior; }
            set
            {
                if (model.isNotEdior != value)
                {
                    model.isNotEdior = value;
                    OnPropertyChanged("IsNotEdior");
                }
            }
        }

        public string Editor1
        {
            get { return model.Editor1; }
            set
            {
                if (model.Editor1 != value)
                {
                    model.Editor1 = value;
                    OnPropertyChanged("Editor1");
                }
            }
        }

        public string Editor2
        {
            get { return model.Editor2; }
            set
            {
                if (model.Editor2 != value)
                {
                    model.Editor2 = value;
                    OnPropertyChanged("Editor2");
                }
            }
        }

        public string Editor3
        {
            get { return model.Editor3; }
            set
            {
                if (model.Editor3 != value)
                {
                    model.Editor3 = value;
                    OnPropertyChanged("Editor3");
                }
            }
        }

        public string Editor4
        {
            get { return model.Editor4; }
            set
            {
                if (model.Editor4 != value)
                {
                    model.Editor4 = value;
                    OnPropertyChanged("Editor4");
                }
            }
        }

        public string Editor5
        {
            get { return model.Editor5; }
            set
            {
                if (model.Editor5 != value)
                {
                    model.Editor5 = value;
                    OnPropertyChanged("Editor5");
                }
            }
        }

        public string Editor6
        {
            get { return model.Editor6; }
            set
            {
                if (model.Editor6 != value)
                {
                    model.Editor6 = value;
                    OnPropertyChanged("Editor6");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}