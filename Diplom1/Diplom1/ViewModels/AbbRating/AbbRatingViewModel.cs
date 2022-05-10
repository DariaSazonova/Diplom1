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

        public AbbRatingViewModel(int level, int applicantid=0)
        {
            GetRating = new();
            if (level != 0)
            {
                var js = Task.Run(async () => await GetRating.GetRatingList( level, applicantid)).Result;
                if (js != null)
                {
                    modellist.list.AddRange(JsonConvert.DeserializeObject<ObservableCollection<AbbRatingModel>>(js));
                }
            }
            else
            {
                for(int i = 1; i < 4; i++)
                {
                    var js = Task.Run(async () => await GetRating.GetRatingList( i, applicantid)).Result;
                    if (js != null)
                    {
                        var l = JsonConvert.DeserializeObject<ObservableCollection<AbbRatingModel>>(js);
                        modellist.list.AddRange(l);
                    }
                }
            }
        }
        
        public List<AbbRatingModel> ListR
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
        public string date
        {
            get
            {
                return model.date;
            }
            set
            {
                if (model.date != value)
                {
                    model.date = value;
                    OnPropertyChanged("date");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
