using System;
using System.Collections.Generic;

namespace TConcept.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Accounts = new HashSet<Accounts>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}
