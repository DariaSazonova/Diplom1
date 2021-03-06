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
    public class InfoColledgeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public InfoColledgeModel model { get; set; } = new();
        private getPhoto getPhoto = new();
        public GetInfoColledge GetInfoColledge = new();
        public InfoColledgeViewModel()
        {
            model.pathPhoto = Task.Run(async () => await getPhoto.get("getColledgePhoto")).Result;
            if (model.pathPhoto == null) Application.Current.MainPage.Toast(getPhoto.error, status.error);
            model.text = Task.Run(async () => await GetInfoColledge.get()).Result;
            if(model.text==null) Application.Current.MainPage.Toast(GetInfoColledge.error, status.error);
        }
        public string PhotoPath
        {
            get { return model.pathPhoto; }
            set
            {
                if (model.pathPhoto != value)
                {
                    model.pathPhoto = value;
                    OnPropertyChanged("PhotoPath");
                }
            }
        }
        public List<string> Text
        {
            get { return model.text; }
            set
            {
                if (model.text != value)
                {
                    model.text = value;
                    OnPropertyChanged("Text");
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
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
