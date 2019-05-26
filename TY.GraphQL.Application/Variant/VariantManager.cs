using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TY.GraphQL.Application.Variant.Interfaces;
using TY.GraphQL.Persistence.Infrastructure;

namespace TY.GraphQL.Application.Variant
{
    public class VariantManager : IVariantManager
    {
        #region Fields

        private readonly IGenericRepository<Data.Variant> _genericVariantRepository;

        #endregion

        #region Ctor

        public VariantManager(IGenericRepository<Data.Variant> genericVariantRepository)
        {
            _genericVariantRepository = genericVariantRepository;
        }

        #endregion

        public async Task<Data.Variant> CreateVariantAsync(Data.Variant variant)
        {
            await _genericVariantRepository.CreateAsync(variant);
            return variant;
        }

        public async Task<Data.Variant> GetVariantById(Guid id)
        {
            return await _genericVariantRepository.GetById(id);
        }

        public async Task<IEnumerable<Data.Variant>> GetBulkVariantContent(IEnumerable<Guid> variantIds)
        {
            return await _genericVariantRepository.Filter(q => variantIds.Contains(q.Id));
        }
    }
}