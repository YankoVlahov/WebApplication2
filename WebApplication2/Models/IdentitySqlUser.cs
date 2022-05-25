using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class IdentitySqlUser
    {
        public IdentitySqlUser()
        {
            IdentitySqlPersonals = new HashSet<IdentitySqlPersonal>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Admin { get; set; }
        public string Password { get; set; } = null!;
        public DateTime ValidTo { get; set; }
        public DateTime RowIn { get; set; }
        public DateTime RowUp { get; set; }

        public virtual ICollection<IdentitySqlPersonal> IdentitySqlPersonals { get; set; }
    }
}
