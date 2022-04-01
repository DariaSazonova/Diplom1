using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom1.Models;
using Diplom1.ViewModels.Quest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Diplom1.ViewModels
{
    public class TestUpdateViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public QuestTestModel model { get; private set; } = new();
        private GetQuestQuestions getQuestions = new();
        public SaveTest savetest { get; private set; } = new();
        public int idQuestionn { get; set; } = -1;
        public TestUpdateViewModel(int level)
        { 
            var jsString = Task.Run(async () => await getQuestions.getQuestQuestions(level)).Result;
            


            if (jsString != "")
            {
                var js = JObject.Parse(jsString);
                model.idQuest = Convert.ToInt32(js["idQuest"]);
                model.listQuestions = JsonConvert.DeserializeObject<List<Questions>>(js["questions"].ToString());
                int i = 0;
                foreach (var it in listQuestions)
                {
                    it.id = i;
                    i++;
                }
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
        public List<Questions> listQuestions
        {
            get
            {
                return model.listQuestions;
            }
            set
            {
                if (model.listQuestions != value)
                {
                    model.listQuestions = value;
                    OnPropertyChanged("listQuestions");
                }
            }
        }

        public List<string> answers
        {
            get
            {
                return model.listQuestions.Where(i=>i.id== idQuestionn).Select(s=>s.answers).FirstOrDefault();
            }
            set
            {
                model.listQuestions[idQuestionn].answers = value;
                OnPropertyChanged("answers");
            }
        }

        public string answer
        {
            get
            {
                return model.listQuestions.Where(i => i.id == idQuestionn).Select(s => s.answer).FirstOrDefault();
            }
            set
            {
                if (model.listQuestions.Where(i => i.id == idQuestionn).Select(s => s.answer).FirstOrDefault() != value)
                {
                    model.listQuestions[idQuestionn].answer = value;
                    OnPropertyChanged("answer");
                }
            }
        }

        public string question
        {
            get
            {
                return model.listQuestions.Where(i => i.id == idQuestionn).Select(s => s.question).FirstOrDefault();
            }
            set
            {
                if (model.listQuestions.Where(i => i.id == idQuestionn).Select(s => s.question).FirstOrDefault() != value)
                {
                    model.listQuestions[idQuestionn].question = value;
                    OnPropertyChanged("question");
                }
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
