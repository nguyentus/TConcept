using System;
using System.Collections.Generic;
using System.Text;

namespace TConcept.DAL.ViewModels
{
    public class OrderInfoViewModel
    {
        public int OrderId { get; set; }
        public string FullName { get; set; }
        public string ProductName { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public double? Price { get; set; }
    }
}
