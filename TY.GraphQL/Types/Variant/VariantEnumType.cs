using GraphQL.Types;
using TY.GraphQL.Data.Enums;

namespace TY.GraphQL.Types.Variant
{
    public class VariantEnumType : EnumerationGraphType
    {
        public VariantEnumType()
        {
            Name = nameof(VariantEnumType);
            AddValue(nameof(VariantTypeEnum.Color), "Variant enum for color", VariantTypeEnum.Color);
            AddValue(nameof(VariantTypeEnum.ShoeSize), "Variant enum for shoe", VariantTypeEnum.ShoeSize);
            AddValue(nameof(VariantTypeEnum.BodySize), "Variant enum for body", VariantTypeEnum.BodySize);
        }
    }
}