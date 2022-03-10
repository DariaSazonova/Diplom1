using Diplom1.Client;
using Diplom1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Diplom1.ViewModels.AbbRating
{
    public class AbbRatingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ListAbbRatingModel modellist { get; set; } = new();
        public AbbRatingModel model { get; set; }
        public GetRating GetRating = new();

        public AbbRatingViewModel(int level)
        {
            modellist.IndicatorIsVisible = true;
            var js = Task.Run(async () => await GetRating.GetRatingList(level)).Result;
            modellist.list = JsonConvert.DeserializeObject<ObservableCollection<AbbRatingModel>>(js); 
            modellist.IndicatorIsVisible = false;
        }
        
        public IEnumerable<AbbRatingModel> ListR
        {
            get { return modellist.list; }
            set
            {
                if (modellist.list != value)
                {
                    modellist.list = value;
                    OnPropertyChanged("ListR");
                }
            }
        }
        public bool IndicatorIsVisible
        {
            get { return modellist.IndicatorIsVisible; }
            set
            {
                if (modellist.IndicatorIsVisible != value)
                {
                    modellist.IndicatorIsVisible = value;
                    OnPropertyChanged("IndicatorIsVisible");
                }
            }
        }
        public string ResultText
        {
            get { return model.ResultText; }
            set
            {
                if (model.ResultText != value)
                {
                    model.ResultText = value;
                    OnPropertyChanged("ResultText");
                }
            }
        }

        public string Fio
        {
            get { return model.Fio; }
            set
            {
                if (model.Fio != value)
                {
                    model.Fio = value;
                    OnPropertyChanged("Fio");
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

        public string level
        {
            get
            {
                return model.level;
            }
            set
            {
                if (model.level != value)
                {
                    model.level = value;
                    OnPropertyChanged("level");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
