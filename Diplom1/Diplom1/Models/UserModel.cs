using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom1.Models
{
    public class UserModel
    {
        public string id { get; set; }
        public  string Surname { get; set; }
        public  string Name { get; set; }
        public  string Patronymic { get; set; }
        public  string Phone { get; set; }
        public  string Login { get; set; }
        public  string DateOfBirth { get; set; }
        public string role { get; set; }
        public string Password { get; set; }
        public bool indicator { get; set; }
    }
}
