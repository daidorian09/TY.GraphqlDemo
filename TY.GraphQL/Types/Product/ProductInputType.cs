using GraphQL.Types;

namespace TY.GraphQL.Types.Product
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = nameof(ProductInputType);

            Field<GuidGraphType>("id", "Product Id");
            Field<NonNullGraphType<StringGraphType>>("name", "Product Name");
            Field<NonNullGraphType<DecimalGraphType>>("unitPrice", "Product Unit Price");
            Field<NonNullGraphType<IntGraphType>>("stockCount", "Product Stock Count");
            Field<StringGraphType>("longDescription", "Product Long Description");
            Field<NonNullGraphType<StringGraphType>>("shortDescription", "Product Short Description");
            Field<NonNullGraphType<BooleanGraphType>>("isDiscountableProduct", "Product Available For Discount");
            Field<ListGraphType<NonNullGraphType<StringGraphType>>>("variants", "Variant Ids");
        }
    }
}