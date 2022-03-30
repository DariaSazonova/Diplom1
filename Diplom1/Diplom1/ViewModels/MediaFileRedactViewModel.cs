using Diplom1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Diplom1.ViewModels
{
    public class MediaFileRedactViewModel : INotifyPropertyChanged
    {
        public MediaPageModel model { get; set; } = new();
        public MediaFileUpdate update { get; set; } = new();
        public MediaFileRedactViewModel()
        {

        }

        public string title
        {
            get { return model.title; }
            set
            {
                if (model.title != value)
                {
                    model.title = value;
                    OnPropertyChanged("title");
                }
            }
        }
        public int id
        {
            get { return model.id; }
            set
            {
                if (model.id != value)
                {
                    model.id = value;
                    OnPropertyChanged("id");
                }
            }
        }
        public bool Indicator
        {
            get { return model.Indicator; }
            set
            {
                if (model.Indicator != value)
                {
                    model.Indicator = value;
                    OnPropertyChanged("Indicator");
                }
            }
        }

        public string path
        {
            get { return model.path; }
            set
            {
                if (model.path != value)
                {
                    model.path = value;
                    OnPropertyChanged("path");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
