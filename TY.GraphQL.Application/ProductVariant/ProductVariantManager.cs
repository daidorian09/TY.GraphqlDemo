using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TY.GraphQL.Application.ProductVariant.Interfaces;
using TY.GraphQL.Application.Variant.Interfaces;
using TY.GraphQL.Persistence.Infrastructure;

namespace TY.GraphQL.Application.ProductVariant
{
    public class ProductVariantManager : IProductVariantManager
    {
        #region Fields

        private readonly IGenericRepository<Data.ProductVariant> _genericProductVariantRepository;
        private readonly IVariantManager _variantManager;

        #endregion

        #region Ctor

        public ProductVariantManager(IGenericRepository<Data.ProductVariant> genericProductVariantRepository, IVariantManager variantManager)
        {
            _genericProductVariantRepository = genericProductVariantRepository;
            _variantManager = variantManager;
        }

        #endregion

        public async Task CreateBulkProductVariantAsync(List<Data.ProductVariant> productVariants)
        {
            await _genericProductVariantRepository.CreateBulkAsync(productVariants);
        }

        public async Task<IEnumerable<Data.Variant>> GetProductVariantByProductId(Guid productId)
        {
            var productVariants = _genericProductVariantRepository
                .Filter(q => q.ProductId.Equals(productId))
                .Result
                .Select(s => s.VariantId);

            var variants = await _variantManager.GetBulkVariantContent(productVariants);

            return variants;
        }
    }
}