using System;
using System.Threading.Tasks;
using TY.GraphQL.Application.Order.Interfaces;
using TY.GraphQL.Persistence.Infrastructure;

namespace TY.GraphQL.Application.Order
{
    public class OrderManager : IOrderManager
    {
        #region Fields

        private readonly IGenericRepository<Data.Order> _genericOrderRepository;

        #endregion

        #region Ctor

        public OrderManager(IGenericRepository<Data.Order> genericOrderRepository)
        {
            _genericOrderRepository = genericOrderRepository;
        }

        #endregion
        public async Task<Data.Order> CreateOrderAsync(Data.Order order)
        {
             await _genericOrderRepository.CreateAsync(order);
             return order;
        }

        public async Task<Data.Order> GetOrderById(Guid id)
        {
            return await _genericOrderRepository.GetById(id);
        }
    }
}