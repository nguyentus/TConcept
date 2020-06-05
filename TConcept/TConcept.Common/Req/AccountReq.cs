using System;
using System.Collections.Generic;
using System.Text;

namespace TConcept.Common.Req
{
    public class AccountReq
    {
        public int AccountId { get; set; }
        public int? RoleId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Notes { get; set; }
    }
}
