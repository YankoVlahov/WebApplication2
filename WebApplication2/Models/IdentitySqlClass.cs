using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class IdentitySqlClass
    {
        public int Id { get; set; }
        public decimal Code { get; set; }
        public string Name { get; set; } = null!;
        public string Note { get; set; } = null!;
        public decimal Delind { get; set; }
        public DateTime RowIn { get; set; }
        public DateTime RowUpdate { get; set; }

        public virtual IdentitySqlTicket IdentitySqlTicket { get; set; } = null!;
    }
}
