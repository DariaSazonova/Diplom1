using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Diplom1.Models
{
    public class ListAbbRatingModel
    {
        public IEnumerable<AbbRatingModel> list { get; set; } = null;
        public bool IndicatorIsVisible { get; set; } = false;
    }
    public class AbbRatingModel
    {
        public int id { get; set; }
        public string ResultText { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }
        public string level { get; set; }
    }
}
