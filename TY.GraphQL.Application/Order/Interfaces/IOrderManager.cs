using System;
using System.Threading.Tasks;

namespace TY.GraphQL.Application.Order.Interfaces
{
    public interface IOrderManager
    {
        Task<Data.Order> CreateOrderAsync(Data.Order order);
        Task<Data.Order> GetOrderById(Guid id);

    }
}