using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class IdentitySqlPersonal
    {
        public IdentitySqlPersonal()
        {
            IdentitySqlTickets = new HashSet<IdentitySqlTicket>();
        }

        public int Id { get; set; }
        public int Userid { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Incompany { get; set; }
        public DateTime EndDate { get; set; }
        public int PositionType { get; set; }
        public string Email { get; set; } = null!;
        public int DepId { get; set; }
        public DateTime RowIn { get; set; }
        public DateTime RowUpdate { get; set; }

        public virtual IdentitySqlDepartment Dep { get; set; } = null!;
        public virtual IdentitySqlPermission PositionTypeNavigation { get; set; } = null!;
        public virtual IdentitySqlUser User { get; set; } = null!;
        public virtual ICollection<IdentitySqlTicket> IdentitySqlTickets { get; set; }
    }
}
