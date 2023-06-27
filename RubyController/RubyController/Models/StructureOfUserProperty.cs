using System;
using System.Collections.Generic;

namespace RubyController.Models
{
    public partial class StructureOfUserProperty
    {
        public int IdStructureOfUserProperty { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }
    }
}
