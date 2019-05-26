using GraphQL.Types;
using TY.GraphQL.Data.Enums;

namespace TY.GraphQL.Types.Order
{
    public class OrderTransactionEnumType : EnumerationGraphType
    {
        public OrderTransactionEnumType()
        {
            Name = nameof(OrderTransactionEnumType);
            AddValue(nameof(TransactionEnum.Cancel), "Order Canceled", TransactionEnum.Cancel);
            AddValue(nameof(TransactionEnum.Cargo), "Order In Cargo", TransactionEnum.Cargo);
            AddValue(nameof(TransactionEnum.Deliver), "Order Delivered", TransactionEnum.Deliver);
            AddValue(nameof(TransactionEnum.PlaceOrder), "Order Created", TransactionEnum.PlaceOrder);
            AddValue(nameof(TransactionEnum.Refund), "Order Refunded", TransactionEnum.Refund);
        }
    }
}