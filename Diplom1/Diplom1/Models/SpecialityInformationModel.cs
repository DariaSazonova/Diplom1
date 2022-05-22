using Diplom1.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom1.Models
{
    public class SpecialityInformationModel
    {
        public bool isNotEdior { get; set; } = PreferencesApp.role == "Абитуриент" ? true : false;
        public bool Indicator { get; set; } = false;
    }
}
