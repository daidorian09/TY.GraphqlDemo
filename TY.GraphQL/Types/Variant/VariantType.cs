using GraphQL.Types;

namespace TY.GraphQL.Types.Variant
{
    public class VariantType : ObjectGraphType<Data.Variant>
    {
        public VariantType()
        {
            Field(f => f.Id, type: typeof(IdGraphType)).Description("Variant Id");
            Field(f => f.Value).Description("Variant Value");
            Field(f => f.CreatedAt, true).Description("Variant Created Date");
            Field(f => f.ModifiedAt, true).Description("Variant Modification Date");
            Field(f => f.IsDeleted).Description("Is Variant Deleted");
            Field(f => f.VariantType, type:typeof(VariantEnumType)).Description("Variant Enum Type");
        }
    }
}