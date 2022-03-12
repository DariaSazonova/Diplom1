using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Diplom1.Models
{
    public class ListAbbRatingModel
    {
        public List<AbbRatingModel> list { get; set; } = new();
        public bool IndicatorIsVisible { get; set; } = false;
    }
    public class AbbRatingModel
    {
        public int id { get; set; }
        public string ResultText { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }
        public string level { get; set; }
        public DateTime date { get; set; }
    }
}
