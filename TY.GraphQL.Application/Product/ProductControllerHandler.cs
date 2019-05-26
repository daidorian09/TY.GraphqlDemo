using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TY.GraphQL.Application.Product.Interfaces;
using TY.GraphQL.Application.Product.Models;
using TY.GraphQL.Application.ProductVariant.Interfaces;
using TY.GraphQL.Application.Variant.Interfaces;

namespace TY.GraphQL.Application.Product
{
    public class ProductControllerHandler : IProductControllerHandler
    {
        #region Fields

        private readonly IProductManager _productManager;
        private readonly IVariantManager _variantManager;
        private readonly IProductVariantManager _productVariantManager;

        #endregion

        #region Ctor

        public ProductControllerHandler(IProductManager productManager, IVariantManager variantManager,IProductVariantManager productVariantManager )
        {
            _productManager = productManager;
            _variantManager = variantManager;
            _productVariantManager = productVariantManager;
        }

        #endregion

        public async Task<Data.Product> CreateProductAsync(ProductViewModel model)
        {
            var product = new Data.Product()
            {
                Id = model.Id,
                UnitPrice = model.UnitPrice,
                Name = model.Name,
                CreatedAt = model.CreatedAt,
                IsDeleted = false,
                LongDescription = model.LongDescription,
                IsDiscountableProduct = model.IsDiscountableProduct,
                ProductContentId = model.ProductContentId,
                StockCount = model.StockCount,
                IsOutOfStock = model.IsOutOfStock,
                ShortDescription = model.ShortDescription,
                ProductUrl = model.ProductUrl
            };

            await _productManager.CreateProductAsync(product);

            var productVariants = new List<Data.ProductVariant>();
            foreach (var variantId in model.Variants)
            {
                var variant = await _variantManager.GetVariantById(variantId);
                var productVariant = new Data.ProductVariant() { Variant = variant, Product = product, Id = Guid.NewGuid(), IsDeleted = false};
                productVariants.Add(productVariant);
            }

            await _productVariantManager.CreateBulkProductVariantAsync(productVariants);

            return product;
        }

        public async Task<Data.Product> GetProductByIdAsync(Guid id)
        {
            return await _productManager.GetProductById(id);
        }

        public async Task<IEnumerable<Data.Product>> GetAll()
        {
            return await _productManager.GetAll();
        }
    }
}