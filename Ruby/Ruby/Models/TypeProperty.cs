using System;
using System.Collections.Generic;

namespace Ruby.Models
{
    public partial class TypeProperty
    {
        public TypeProperty()
        {
            Properties = new HashSet<Property>();
        }

        public int IdTypeProperty { get; set; }
        public string TypePropertyName { get; set; } = null!;

        public virtual ICollection<Property> Properties { get; set; }
    }
}
