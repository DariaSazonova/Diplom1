using Diplom1.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom1.Models
{
    public class SpecialityInformationModel
    {
        public bool isNotEdior { get; set; } = PreferencesApp.role == "Абитуриент" ? true : false;
        public string Editor1 { get; set; }
        public string Editor2 { get; set; }
        public string Editor3 { get; set; }
        public string Editor4 { get; set; }
        public string Editor5 { get; set; }
        public string Editor6 { get; set; }

    }
}
