using Diplom1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Diplom1.ViewModels.Quest
{
    public  class QuestResultViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public QuestResultModel model = new();
        public ICommand getQuestRating;
        public QuestResultViewModel(int countTrueAnswers, int countAll, int level)
        {
            ResultTest = $"Уровень {level}\n\nРезультат Вашего теста:\n {countTrueAnswers} из {countAll}";
            GetQuestResult getQuestResult = new();
            aboutTest = Task.Run(async()=>await getQuestResult.getRatingApplicant(this, level)).Result;
            
           

        }

        public bool IndicatorIsVisible
        {
            get
            {
                return model.IndicatorIsVisible;
            }
            set
            {
                if (model.IndicatorIsVisible != value)
                {
                    model.IndicatorIsVisible = value;
                    OnPropertyChanged("IndicatorIsVisible");
                }
            }
        }

        public string ImageSource
        {
            get
            {
                return model.ImageSource;
            }
            set
            {
                if (model.ImageSource != value)
                {
                    model.ImageSource = value;
                    OnPropertyChanged("ImageSource");
                }
            }
        }

        public string aboutTest
        {
            get
            {
                return model.aboutResult;
            }
            set
            {
                if (model.aboutResult != value)
                {
                    model.aboutResult = value;
                    OnPropertyChanged("aboutTest");
                }
            }
        }

        public string ResultTest
        {
            get
            {
                return model.ResultTest;
            }
            set
            {
                if (model.ResultTest != value)
                {
                    model.ResultTest = value;
                    OnPropertyChanged("ResultTest");
                }
            }
        }

        
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
