using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Diplom1.Models
{
    public class TestResultModel
    {
        public string question { get; set; }
        public string trueAnswer{ get; set; }
        public string yourAnswer { get; set; }
        public Color color { get; set; }
    }
}
