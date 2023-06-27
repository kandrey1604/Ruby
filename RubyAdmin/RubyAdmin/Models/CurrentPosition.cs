using System;
using System.Collections.Generic;

namespace RubyAdmin.Models
{
    public partial class CurrentPosition
    {
        public CurrentPosition()
        {
            StructureOfEmployees = new HashSet<StructureOfEmployee>();
        }

        public int IdCurrentPosition { get; set; }
        public string NameCurrentPosition { get; set; } = null!;

        public virtual ICollection<StructureOfEmployee> StructureOfEmployees { get; set; }
    }
}
