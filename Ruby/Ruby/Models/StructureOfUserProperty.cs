using System;
using System.Collections.Generic;

namespace Ruby.Models
{
    public partial class StructureOfUserProperty
    {
        public int IdStructureOfUserProperty { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }

        public virtual Property Property { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
    