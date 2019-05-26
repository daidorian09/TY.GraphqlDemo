using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TY.GraphQL.Application.ProductOrder.Interfaces
{
    public interface IProductOrderControllerHandler
    {
        Task<IEnumerable<Data.Product>> GetProductOrderByOrderId(Guid orderId);
    }
}