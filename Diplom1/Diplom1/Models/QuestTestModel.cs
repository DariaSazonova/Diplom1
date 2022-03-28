using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom1.Models
{
    public class QuestTestModel
    {
        public int idQuest { get; set; }
        public IEnumerable<Questions> listQuestions { get; set; }
        public bool? Indicator { get; set; } = false;
        public float? progress { get; set; } = 0;

    }
    public class Questions
    {
        public string question  { get; set; }
        public IEnumerable<string> answers { get; set; }
        public string answer   { get; set; }
        public bool? IsAnswered { get; set; }
        public bool? accepted { get; set; }
    }
    public class buttonClickQuest
    {
        public int id { get; set; }
        public string answer { get; set; }
        public bool isAnswer { get; set; } = false;
    }
}
