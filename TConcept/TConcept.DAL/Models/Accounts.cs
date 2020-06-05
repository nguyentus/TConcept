using System;
using System.Collections.Generic;

namespace TConcept.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            Customers = new HashSet<Customers>();
        }

        public int AccountId { get; set; }
        public int? RoleId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Notes { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
