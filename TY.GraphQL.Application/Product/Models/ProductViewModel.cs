using System;
using System.Collections.Generic;

namespace TY.GraphQL.Application.Product.Models
{
    public class ProductViewModel
    {
        public Guid Id => Guid.NewGuid();
        public DateTime? CreatedAt => DateTime.Now;
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockCount { get; set; }
        public string ProductContentId => Guid.NewGuid().ToString("N");
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public string ProductUrl { get; set; }
        public bool IsDiscountableProduct { get; set; }
        public bool IsOutOfStock { get; set; }
        public IEnumerable<Guid> Variants { get; set; }
    }
}