using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TY.GraphQL.Application.ProductOrder.Interfaces;

namespace TY.GraphQL.Application.ProductOrder
{
    public class ProductOrderControllerHandler : IProductOrderControllerHandler
    {
        #region Fields

        private readonly IProductOrderManager _productOrderManager;

        #endregion

        #region Ctor

        public ProductOrderControllerHandler(IProductOrderManager productOrderManager)
        {
            _productOrderManager = productOrderManager;
        }

        #endregion

        public async Task<IEnumerable<Data.Product>> GetProductOrderByOrderId(Guid orderId)
        {
            return await _productOrderManager.GetProductOrderByOrderId(orderId);
        }
    }
}