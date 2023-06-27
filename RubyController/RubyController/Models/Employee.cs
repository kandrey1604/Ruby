using System;
using System.Collections.Generic;

namespace RubyController.Models
{
    public partial class Employee
    {
        public int IdEmployee { get; set; }
        public string FirstNameEmployee { get; set; } = null!;
        public string SecondNameEmployee { get; set; } = null!;
        public string? MiddleNameEmployee { get; set; }
        public string LoginEmployee { get; set; } = null!;
        public string PasswordEmployee { get; set; } = null!;

    }
}
