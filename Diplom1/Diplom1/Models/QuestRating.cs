﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom1.Models
{
    public partial class QuestRatingModel
    {
        public int id { get; set; }
        public int IdApplicant { get; set; }
        public int IdQuest { get; set; }
        public string Result { get; set; }
        public string date { get; set; } = "";
        public string answers { get; set; } = "";
    }
}
