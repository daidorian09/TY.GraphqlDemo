using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TY.GraphQL.Application.Product.Interfaces;
using TY.GraphQL.Application.ProductOrder.Interfaces;
using TY.GraphQL.Persistence.Infrastructure;

namespace TY.GraphQL.Application.ProductOrder
{
    public class ProductOrderManager : IProductOrderManager
    {
        #region Fields

        private readonly IGenericRepository<Data.ProductOrder> _genericProductOrderRepository;
        private readonly IProductManager _productManager;

        #endregion

        #region Ctor

        public ProductOrderManager(IGenericRepository<Data.ProductOrder> genericProductOrderRepository, IProductManager productManager)
        {
            _genericProductOrderRepository = genericProductOrderRepository;
            _productManager = productManager;
        }

        #endregion
        public async Task CreateBulkProductOrderAsync(List<Data.ProductOrder> productOrders)
        {
            await _genericProductOrderRepository.CreateBulkAsync(productOrders);
        }

        public async Task<IEnumerable<Data.Product>> GetProductOrderByOrderId(Guid orderId)
        {
            var orderProducts = _genericProductOrderRepository
                .Filter(q => q.Order.Id.Equals(orderId))
                .Result
                .Select(s => s.ProductId);

            var products = await _productManager.GetBulkProductContent(orderProducts);

            return products;
        }
    }
}