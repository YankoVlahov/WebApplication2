using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class IdentitySqlTicket
    {
        public int Id { get; set; }
        public string Note { get; set; } = null!;
        public int FromUser { get; set; }
        public int ToUser { get; set; }
        public int DocId { get; set; }
        public int ClassId { get; set; }
        public int Status { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public DateTime RowIn { get; set; }
        public DateTime RowUpdate { get; set; }

        public virtual IdentitySqlClass Class { get; set; } = null!;
        public virtual IdentitySqlPersonal FromUserNavigation { get; set; } = null!;
    }
}
