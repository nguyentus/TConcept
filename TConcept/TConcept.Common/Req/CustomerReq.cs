using System;
using System.Collections.Generic;
using System.Text;

namespace TConcept.Common.Req
{
    public class CustomerReq
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public int? AccountId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string Notes { get; set; }
    }
}
