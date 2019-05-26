using System;
using System.Threading.Tasks;
using TY.GraphQL.Application.ProductOrder.Models;

namespace TY.GraphQL.Application.Order.Interfaces
{
    public interface IOrderControllerHandler
    {
        Task<Data.Order> CreateOrderAsync(OrderViewModel model);
        Task<Data.Order> GetOrderById (Guid id);
    }
}