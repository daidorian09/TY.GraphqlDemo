using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TY.GraphQL.Data.Enums;

namespace TY.GraphQL.Data
{
    public class Variant : IBaseEntity
    {
        public Variant()
        {
            ProductVariants = new HashSet<ProductVariant>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string Value { get; set; }
        public VariantTypeEnum VariantType { get; set; }
        public ICollection<ProductVariant> ProductVariants { get; }
    }
}