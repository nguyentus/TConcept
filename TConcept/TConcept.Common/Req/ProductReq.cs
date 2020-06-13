using System;
using System.Collections.Generic;
using System.Text;

namespace TConcept.Common.Req
{
    public class ProductReq
    {
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
        public string Image { get; set; }
        public string Notes { get; set; }
    }
}
