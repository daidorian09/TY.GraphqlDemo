using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TY.GraphQL.Data
{
    public class Product : IBaseEntity
    {
        public Product()
        {
            ProductVariants = new HashSet<ProductVariant>();
            ProductOrders = new HashSet<ProductOrder>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockCount { get; set; }
        public string ProductContentId { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public string ProductUrl { get; set; }
        public bool IsDiscountableProduct { get; set; }
        public bool IsOutOfStock { get; set; }
        public ICollection<ProductVariant> ProductVariants { get; }
        public ICollection<ProductOrder> ProductOrders { get; }
    }
}