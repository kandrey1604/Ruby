using System;
using System.Collections.Generic;

namespace Ruby.Models
{
    public partial class StructureOfEmployee
    {
        public int IdStructureOfEmployee { get; set; }
        public int PropertyId { get; set; }
        public int EmployeeId { get; set; }
        public int CurrentPositionId { get; set; }

        public virtual CurrentPosition CurrentPosition { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual Property Property { get; set; } = null!;
    }
}
