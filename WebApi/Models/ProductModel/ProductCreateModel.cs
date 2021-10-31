using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.ProductModel
{
    public class ProductCreateModel
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
