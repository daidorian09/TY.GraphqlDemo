using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TY.GraphQL.Application.ProductVariant.Interfaces
{
    public interface IProductVariantControllerHandler
    {
        Task<IEnumerable<Data.Variant>> GetProductVariantByProductId(Guid productId);
    }
}