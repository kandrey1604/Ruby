using System;
using System.Collections.Generic;

namespace RubyController.Models
{
    public partial class Property
    {
        public int IdProperty { get; set; }
        public string NameProperty { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Location { get; set; } = null!;
        public decimal Square { get; set; }
        public int BedroomCount { get; set; }
        public int KitchenCount { get; set; }
        public int BathroomCount { get; set; }
        public decimal Price { get; set; }
        public int TypePropertyId { get; set; }
    }
}
