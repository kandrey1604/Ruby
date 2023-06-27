using System;
using System.Collections.Generic;

namespace RubyController.Models
{
    public partial class UserCard
    {
        public int IdUserCard { get; set; }
        public string CardNumber { get; set; } = null!;
        public string CardHolder { get; set; } = null!;
        public string Validity { get; set; } = null!;
        public int UserId { get; set; }
    }
}
