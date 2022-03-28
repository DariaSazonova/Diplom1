using Diplom1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Diplom1.ViewModels
{
    public class MediaPageViewModel : INotifyPropertyChanged
    {
        public List<MediaPageModel> model { get; set; } = new();
        public getMediaFiles getMediaFiles = new();

        public MediaPageViewModel()
        {
            model = Task.Run(async()=>await getMediaFiles.get()).Result;
        }
        public List<MediaPageModel> mediaList
        {
            get { return model; }
            set
            {
                if (model != value)
                {
                    model = value;
                    OnPropertyChanged("mediaList");
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
