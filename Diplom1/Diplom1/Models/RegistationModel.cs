using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom1.Models
{
    public class RegistationModel
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PasswordAgain { get; set; } = null!;
        public int IdApplicants { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string DateOfBirth { get; set; }
        public bool ButtonEnabled { get; set; } = false;
        public bool IndicatorIsVisible { get; set; } = false;
    }
}
