using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom1.Models
{
    public class MediaPageModel
    {
        public int id { get; set; }
        public string path { get; set; }   
        public string title { get; set; }
        public string midiatype { get; set; } = "video";
        public bool Indicator { get; set; } = false;
    }
}
