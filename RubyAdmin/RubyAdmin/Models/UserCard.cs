using System;
using System.Collections.Generic;

namespace RubyAdmin.Models
{
    public partial class UserCard
    {
        public int IdUserCard { get; set; }
        public string CardNumber { get; set; } = null!;
        public string CardHolder { get; set; } = null!;
        public string Validity { get; set; } = null!;
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
