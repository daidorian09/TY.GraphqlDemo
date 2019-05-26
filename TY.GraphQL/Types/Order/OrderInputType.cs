using GraphQL.Types;

namespace TY.GraphQL.Types.Order
{
    public class OrderInputType : InputObjectGraphType
    {
        public OrderInputType()
        {
            Name = nameof(OrderInputType);
            Field<GuidGraphType>("id", "Order Id");
            Field<NonNullGraphType<StringGraphType>>("address", "Order Address");
            Field<NonNullGraphType<StringGraphType>>("phoneNumber", "Order PhoneNumber");
            Field<NonNullGraphType<StringGraphType>>("city", "Order City");
            Field<NonNullGraphType<StringGraphType>>("country", "Order Country");
            Field<NonNullGraphType<StringGraphType>>("email", "Order Email");
            Field<StringGraphType>("zipCode", "Order ZipCode");
            Field<ListGraphType<NonNullGraphType<ProductOrderInputType>>>("productOrders", "Ordered Products");
        }
    }
}