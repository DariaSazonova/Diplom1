﻿using System;
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
        public List<QuestTestModel> model { get; private set; } = new();
        private GetQuestQuestions getQuestions = new();
        public SaveTest savetest { get; private set; } = new();
        public TestUpdateViewModel(int level)
        {
            model.Add(new QuestTestModel());
            IndicatorIsVisible = true;
            var jsString = Task.Run(async () => await getQuestions.getQuestQuestions(level)).Result;
            var js = JObject.Parse(jsString);



            model[0].idQuest = Convert.ToInt32(js["idQuest"]);
            model[0].listQuestions = JsonConvert.DeserializeObject<List<Questions>>(js["questions"].ToString());
            IndicatorIsVisible = false;

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
        public IEnumerable<Questions> listQuestions
        {
            get
            {
                return model[0].listQuestions;
            }
            set
            {
                if (model[0].listQuestions != value)
                {
                    model[0].listQuestions = value;
                    OnPropertyChanged("listQuestions");
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
