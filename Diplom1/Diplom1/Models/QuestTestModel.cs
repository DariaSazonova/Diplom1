using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Diplom1.Models
{
    public class QuestTestModel
    {
        public int idQuest { get; set; }
        public List<Questions> listQuestions { get; set; } = new();
        public bool? Indicator { get; set; } = false;
        public float? progress { get; set; } = 0;

    }
    public class Questions
    {
        public int id { get; set; }
        public string question { get; set; } = "";
        public List<string> answers { get; set; } = new();
        public string answer { get; set; } = "";
        public bool? IsAnswered { get; set; } = false;
        public bool? accepted { get; set; } = false;
    }
    public class buttonClickQuest
    {
        public int id { get; set; }
        public string answer { get; set; }
        public bool isAnswer { get; set; } = false;
    }
    public class Answers
    {
        public int id { get; set; }
        public string yourAnswer { get; set; }
        public string trueAnswer { get; set; }

    }

}
