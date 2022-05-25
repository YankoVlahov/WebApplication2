using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class IdentitySqlPermission
    {
        public IdentitySqlPermission()
        {
            IdentitySqlPersonals = new HashSet<IdentitySqlPersonal>();
        }

        public int Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; } = null!;
        public decimal ToRegUser { get; set; }
        public decimal ToRegTicket { get; set; }
        public decimal Excel { get; set; }
        public decimal ToGiveStatus { get; set; }
        public decimal ReadOnly { get; set; }
        public DateTime RowIn { get; set; }
        public DateTime RowUpdate { get; set; }

        public virtual ICollection<IdentitySqlPersonal> IdentitySqlPersonals { get; set; }
    }
}
