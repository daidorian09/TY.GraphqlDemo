using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TY.GraphQL.Application.Variant.Interfaces
{
    public interface IVariantManager
    {
        Task<Data.Variant> CreateVariantAsync(Data.Variant variant);
        Task<Data.Variant> GetVariantById(Guid id);
        Task<IEnumerable<Data.Variant>> GetBulkVariantContent(IEnumerable<Guid> variantIds);
    }
}