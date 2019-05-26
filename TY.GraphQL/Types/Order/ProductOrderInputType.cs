using GraphQL.Types;

namespace TY.GraphQL.Types.Order
{
    public class ProductOrderInputType : InputObjectGraphType
    {
        public ProductOrderInputType()
        {
            Name = nameof(ProductOrderInputType);
            Field<NonNullGraphType<StringGraphType>>("productId", "Product Id");
            Field<NonNullGraphType<IntGraphType>>("quantity", "Product Quantity");
        }
    }
}