using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TY.GraphQL.Data.Enums;

namespace TY.GraphQL.Data
{
    public class Order : IBaseEntity
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Total { get; set; }
        public string TransactionId { get; set; }
        public TransactionEnum TransactionType { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string TrackingNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; }
    }
}