using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TY.GraphQL.Application.ProductVariant.Interfaces
{
    public interface IProductVariantManager
    {
        Task CreateBulkProductVariantAsync(List<Data.ProductVariant> productVariants);

        Task<IEnumerable<Data.Variant>> GetProductVariantByProductId(Guid productId);
    }
}