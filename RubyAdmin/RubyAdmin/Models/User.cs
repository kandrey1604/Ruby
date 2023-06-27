using System;
using System.Collections.Generic;

namespace RubyAdmin.Models
{
    public partial class User
    {
        public User()
        {
            StructureOfUserProperties = new HashSet<StructureOfUserProperty>();
            UserCards = new HashSet<UserCard>();
        }

        public int IdUser { get; set; }
        public string LoginUser { get; set; } = null!;
        public string PasswordUser { get; set; } = null!;

        public virtual ICollection<StructureOfUserProperty> StructureOfUserProperties { get; set; }
        public virtual ICollection<UserCard> UserCards { get; set; }
    }
}
