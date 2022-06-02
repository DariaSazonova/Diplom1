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
        public QuestTestModel model { get; private set; } = new();
        public GetQuestQuestions getQuestions = new();
        public QuestViewModel(int level)
        {
            model =new QuestTestModel();
            var jsString = Task.Run(async () => await getQuestions.getQuestQuestions(level)).Result;
            if (!string.IsNullOrWhiteSpace(jsString) && jsString!=null)
            {
                var js = JObject.Parse(jsString);
                model.idQuest = Convert.ToInt32(js["idQuest"]);
                model.listQuestions = JsonConvert.DeserializeObject<List<Questions>>(js["questions"].ToString());
                
            }
            

        }

        public float? progress
        {
            set
            {
                if (model.progress != value)
                {
                    float count = model.listQuestions.Count();
                    float step = 1f / count;
                    model.progress = value == -1 ? 0 : model.progress += step;
                    OnPropertyChanged("progress");
                }
            }
            get
            {
                return model.progress;
            }


        }
        public IEnumerable<Questions> ListQuestions
        {
            get
            {
                yield return model.listQuestions.FirstOrDefault(s => s.accepted == false);
            }
            set
            {
                if (model.listQuestions != value)
                {
                    model.listQuestions = (List<Questions>)value;
                    OnPropertyChanged("ListQuestions");
                }
            }
        }

        public string Question
        {
            get
            {
                return model.listQuestions.FirstOrDefault(s => s.accepted == false).question;
            }
            set
            {
                model.listQuestions[model.listQuestions.IndexOf(model.listQuestions.FirstOrDefault(s => s.accepted == false))].question = value;
                    OnPropertyChanged("ListQuestions");
            }
        }

        public List<string> Answers
        {
            get
            {
                return model.listQuestions.Where(s => s.accepted == false).FirstOrDefault().answers;
            }
            set
            {
                model.listQuestions[model.listQuestions.IndexOf(model.listQuestions.FirstOrDefault(s => s.accepted == false))].answers = value;
                OnPropertyChanged("Answers");
            }
        }


        public bool? IndicatorIsVisible
        {
            get { return model.Indicator; }
            set
            {
                    model.Indicator = value;
                    OnPropertyChanged("IndicatorIsVisible");
                
            }
        }

        public int idQuest
        {
            get { return model.idQuest; }
            set
            {
                if (model.idQuest != value)
                {
                    model.idQuest = value;
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
