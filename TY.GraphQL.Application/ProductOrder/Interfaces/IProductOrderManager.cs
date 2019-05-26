using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TY.GraphQL.Application.ProductOrder.Interfaces
{
    public interface IProductOrderManager
    {
        Task CreateBulkProductOrderAsync(List<Data.ProductOrder> productOrders);
        Task<IEnumerable<Data.Product>> GetProductOrderByOrderId(Guid orderId);
    }
}