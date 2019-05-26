using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TY.GraphQL.Application.Order.Interfaces;
using TY.GraphQL.Application.Product.Interfaces;
using TY.GraphQL.Application.ProductOrder.Interfaces;
using TY.GraphQL.Application.ProductOrder.Models;

namespace TY.GraphQL.Application.Order
{
    public class OrderControllerHandler : IOrderControllerHandler
    {
        #region Fields

        private readonly IOrderManager _orderManager;
        private readonly IProductManager _productManager;
        private readonly IProductOrderManager _productOrderManager;

        #endregion

        #region Ctor

        public OrderControllerHandler(IOrderManager orderManager, IProductManager productManager, IProductOrderManager productOrderManager)
        {
            _orderManager = orderManager;
            _productManager = productManager;
            _productOrderManager = productOrderManager;
        }

        #endregion

        public async Task<Data.Order> CreateOrderAsync(OrderViewModel model)
        {
            var order = new Data.Order()
            {
                Id = model.Id,
                Address = model.Address,
                TrackingNumber = model.TrackingNumber,
                TransactionId = model.TransactionId,
                TransactionType = model.TransactionType,
                City = model.City,
                CreatedAt = model.CreatedAt,
                IsDeleted = false,
                Country = model.Country,
                ZipCode = model.ZipCode,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var total = 0.0m;
            var productOrders = new List<Data.ProductOrder>();
            foreach (var productOrder in model.ProductOrders)
            {
                var product = await _productManager.GetProductById(productOrder.ProductId);
                total += productOrder.Quantity * product.UnitPrice;
                productOrders.Add(new Data.ProductOrder() {Product = product, Order = order, Id = Guid.NewGuid(), IsDeleted = false});
            }

            order.Total = total;

            await _orderManager.CreateOrderAsync(order);
            await _productOrderManager.CreateBulkProductOrderAsync(productOrders);

            return order;
        }

        public async Task<Data.Order> GetOrderById(Guid id)
        {
            return await _orderManager.GetOrderById(id);
        }
    }
}