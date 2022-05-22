using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Diplom1.ViewModels.Quest
{
    public class QuestFirstViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool Indicator { get; set; } = false;
        public ICommand QuestLevel1Clicked { protected set; get; }
        public ICommand QuestLevel2Clicked { protected set; get; }
        public ICommand QuestLevel3Clicked { protected set; get; }
        public ICommand QuestHistoryClicked { protected set; get; }

        public QuestFirstViewModel()
        {
            QuestLevel1Clicked = new QuestLevel1Clicked(this);
            QuestLevel2Clicked = new QuestLevel2Clicked(this);
            QuestLevel3Clicked = new QuestLevel3Clicked(this);
            QuestHistoryClicked = new QuestHistoryClicked(this);
        }
        public bool IndicatorIsVisible
        {
            get { return Indicator; }
            set
            {
                Indicator = value;
                OnPropertyChanged("IndicatorIsVisible");
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
