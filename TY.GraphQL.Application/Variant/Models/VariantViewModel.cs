using System;
using TY.GraphQL.Data.Enums;

namespace TY.GraphQL.Application.Variant.Models
{
    public class VariantViewModel
    {
        public Guid Id => Guid.NewGuid();

        public DateTime? CreatedAt => DateTime.Now;

        public string Value { get; set; }

        public VariantTypeEnum VariantType { get; set; }
    }
}