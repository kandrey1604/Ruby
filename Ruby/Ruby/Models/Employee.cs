using System;
using System.Collections.Generic;

namespace Ruby.Models
{
    public partial class Employee
    {
        public Employee()
        {
            StructureOfEmployees = new HashSet<StructureOfEmployee>();
        }

        public int IdEmployee { get; set; }
        public string FirstNameEmployee { get; set; } = null!;
        public string SecondNameEmployee { get; set; } = null!;
        public string? MiddleNameEmployee { get; set; }
        public string LoginEmployee { get; set; } = null!;
        public string PasswordEmployee { get; set; } = null!;

        public virtual ICollection<StructureOfEmployee> StructureOfEmployees { get; set; }
    }
}
