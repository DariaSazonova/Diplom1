using Diplom1.Models;
using Diplom1.Toast;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diplom1.ViewModels
{
    public class MediaPageViewModel : INotifyPropertyChanged
    {
        public List<MediaPageModel> model { get; set; } = new();
        public getMediaFiles getMediaFiles = new();
        public MediaFileUpdate update { get; set; } = new();

        public MediaPageViewModel()
        {
            var list = Task.Run(async()=>await getMediaFiles.get()).Result;
            if (list == null)
            {
                Application.Current.MainPage.Toast(getMediaFiles.error, status.error);
            }
            else
            {
                model = list;
            }
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
