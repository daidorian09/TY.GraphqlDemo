using System;

namespace TY.GraphQL.Application.Product.Models
{
    public class ProductOrderViewModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}