using System;
using System.Collections.Generic;
using TY.GraphQL.Application.Product.Models;
using TY.GraphQL.Data.Enums;

namespace TY.GraphQL.Application.ProductOrder.Models
{
    public class OrderViewModel
    {
        public Guid Id => Guid.NewGuid();
        public DateTime? CreatedAt => DateTime.Now;
        public string Name { get; set; }
        public string TrackingNumber => Guid.NewGuid().ToString("N");
        public string TransactionId => Guid.NewGuid().ToString("N");
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public TransactionEnum TransactionType => TransactionEnum.PlaceOrder;
        public IEnumerable<ProductOrderViewModel> ProductOrders { get; set; }
    }
}