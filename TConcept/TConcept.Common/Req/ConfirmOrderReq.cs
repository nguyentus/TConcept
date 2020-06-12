using System;
using System.Collections.Generic;
using System.Text;

namespace TConcept.Common.Req
{
    public class ConfirmOrderReq
    {
        public int CustomerId { get; set; }
        public string Notes { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
