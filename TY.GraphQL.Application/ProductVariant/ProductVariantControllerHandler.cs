using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TY.GraphQL.Application.ProductVariant.Interfaces;

namespace TY.GraphQL.Application.ProductVariant
{
    public class ProductVariantControllerHandler : IProductVariantControllerHandler
    {
        #region Fields

        private readonly IProductVariantManager _productVariantManager;

        #endregion

        #region Ctor

        public ProductVariantControllerHandler(IProductVariantManager productVariantManager)
        {
            _productVariantManager = productVariantManager;
        }

        #endregion

        public async Task<IEnumerable<Data.Variant>> GetProductVariantByProductId(Guid productId)
        {
            return await _productVariantManager.GetProductVariantByProductId(productId);
        }
    }
}