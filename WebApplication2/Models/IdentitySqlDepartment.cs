using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class IdentitySqlDepartment
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; } = null!;
        public int ManagerId { get; set; }
        public decimal Delind { get; set; }
        public DateTime RowIn { get; set; }
        public DateTime RowUpdate { get; set; }

        public virtual IdentitySqlPersonal IdentitySqlPersonal { get; set; } = null!;
    }
}
