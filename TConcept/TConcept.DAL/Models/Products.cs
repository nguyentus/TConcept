using System;
using System.Collections.Generic;

namespace TConcept.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public double? Price { get; set; }
        public int? Stock { get; set; }
        public string Notes { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
