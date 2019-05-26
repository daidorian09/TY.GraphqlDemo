using System;
using System.Threading.Tasks;
using TY.GraphQL.Application.Variant.Interfaces;
using TY.GraphQL.Application.Variant.Models;

namespace TY.GraphQL.Application.Variant
{
    public class VariantControllerHandler : IVariantControllerHandler
    {
        #region Fields

        private readonly IVariantManager _variantManager;

        #endregion

        #region Ctor

        public VariantControllerHandler(IVariantManager variantManager)
        {
            _variantManager = variantManager;
        }

        #endregion

        public async Task<Data.Variant> CreateVariantAsync(VariantViewModel model)
        {
            var variant = new Data.Variant()
            {
                Value = model.Value,
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                IsDeleted = false,
                VariantType = model.VariantType
            };
            return await _variantManager.CreateVariantAsync(variant);
        }

        public async Task<Data.Variant> GetVariantByIdAsync(Guid id)
        {
            return await _variantManager.GetVariantById(id);
        }
    }
}