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
        public string midiatype { get; set; } = "file";
        public bool Indicator { get; set; } = false;
    }
}
