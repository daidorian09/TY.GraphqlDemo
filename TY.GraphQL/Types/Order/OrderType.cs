using GraphQL.Types;
using TY.GraphQL.Application.ProductOrder.Interfaces;
using TY.GraphQL.Types.Product;

namespace TY.GraphQL.Types.Order
{
    public class OrderType : ObjectGraphType<Data.Order>
    {
        public OrderType(IProductOrderControllerHandler productOrderControllerHandler)
        {
            Name = nameof(OrderType);
            Field(f => f.Id, type: typeof(IdGraphType)).Description("Order Id");
            Field(f => f.IsDeleted).Description("Order Is Deleted");
            Field(f => f.Total).Description("Order Grand Total");
            Field(f => f.CreatedAt, true).Description("Product Created Date");
            Field(f => f.ModifiedAt, true).Description("Product Modification Date");
            Field(f => f.Address).Description("Order Address");
            Field(f => f.City).Description("Order City");
            Field(f => f.Country).Description("Order Country");
            Field(f => f.Email).Description("Order Email");
            Field(f => f.PhoneNumber).Description("Order Phone Number");
            Field(f => f.TrackingNumber).Description("Order Tracking Number");
            Field(f => f.TransactionId).Description("Order Transaction Id");
            Field(f => f.ZipCode).Description("Order Zip Code");
            Field(f => f.TransactionType, type: typeof(OrderTransactionEnumType)).Description("Order Transaction Type");
            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productOrderControllerHandler.GetProductOrderByOrderId(context.Source.Id).Result
            );
        }
    }
}