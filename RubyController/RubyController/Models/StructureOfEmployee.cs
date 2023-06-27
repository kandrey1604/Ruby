using System;
using System.Collections.Generic;

namespace RubyController.Models
{
    public partial class StructureOfEmployee
    {
        public int IdStructureOfEmployee { get; set; }
        public int PropertyId { get; set; }
        public int EmployeeId { get; set; }
        public int CurrentPositionId { get; set; }
    }
}
