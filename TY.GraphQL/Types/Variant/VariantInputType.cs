using GraphQL.Types;

namespace TY.GraphQL.Types.Variant
{
    public class VariantInputType : InputObjectGraphType
    {
        public VariantInputType()
        {
            Name = nameof(VariantInputType);
            Field<GuidGraphType>("id", "Variant Id");
            Field<NonNullGraphType<StringGraphType>>("value", "Variant Value");
            Field<NonNullGraphType<VariantEnumType>>("variantType", "Variant Type");
        }
    }
}