using System;
using System.Collections.Generic;

namespace TConcept.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public int? AccountId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string Notes { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
