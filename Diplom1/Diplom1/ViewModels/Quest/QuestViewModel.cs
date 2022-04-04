using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom1.Models;
using Diplom1.Toast;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Diplom1.ViewModels.Quest
{
    public class QuestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<QuestTestModel> model { get; private set; } = new();
        private GetQuestQuestions getQuestions = new();
        public QuestViewModel(int level)
        {
            model.Add(new QuestTestModel());
            var jsString = Task.Run(async () => await getQuestions.getQuestQuestions(level)).Result;
            if (!string.IsNullOrWhiteSpace(jsString))
            {
                var js = JObject.Parse(jsString);
                model[0].idQuest = Convert.ToInt32(js["idQuest"]);
                model[0].listQuestions = JsonConvert.DeserializeObject<List<Questions>>(js["questions"].ToString());
            }
            else
            {
                Application.Current.MainPage.Toast("В этом тесте еще нет вопросов", status.warning);
                
            }

        }

        public float? progress
        {
            set
            {
                if (model[0].progress != value)
                {
                    float count = model[0].listQuestions.Count();
                    float step = 1f / count;
                    model[0].progress = value == -1 ? 0 : model[0].progress += step;
                    OnPropertyChanged("progress");
                }
            }
            get
            {
                return model[0].progress;
            }


        }
        public IEnumerable<Questions> ListQuestions
        {
            get
            {
                yield return model[0].listQuestions.FirstOrDefault(s => s.accepted == false);
            }
            set
            {
                if (model[0].listQuestions != value)
                {
                    model[0].listQuestions = (List<Questions>)value;
                    OnPropertyChanged("ListQuestions");
                }
            }
        }


        public bool? IndicatorIsVisible
        {
            get { return model[0].Indicator; }
            set
            {
                    model[0].Indicator = value;
                    OnPropertyChanged("IndicatorIsVisible");
                
            }
        }

        public int idQuest
        {
            get { return model[0].idQuest; }
            set
            {
                if (model[0].idQuest != value)
                {
                    model[0].idQuest = value;
                    OnPropertyChanged("idQuest");
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
