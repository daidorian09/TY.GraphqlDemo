using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TY.GraphQL.Data
{
    public class ProductVariant : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid VariantId { get; set; }
        public Variant Variant { get; set; }
    }
}