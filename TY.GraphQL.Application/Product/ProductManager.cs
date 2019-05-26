using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TY.GraphQL.Application.Product.Interfaces;
using TY.GraphQL.Persistence.Infrastructure;

namespace TY.GraphQL.Application.Product
{
    public class ProductManager : IProductManager
    {
        #region Fields

        private readonly IGenericRepository<Data.Product> _genericProductRepository;

        #endregion

        #region Ctor

        public ProductManager(IGenericRepository<Data.Product> genericProductRepository)
        {
            _genericProductRepository = genericProductRepository;
        }

        #endregion

        public async Task<Data.Product> CreateProductAsync(Data.Product product)
        {
            var isProductFound = _genericProductRepository.Filter(q => q.Name.ToLower().Equals(product.Name.ToLower())).Result.Any();

            if (isProductFound)
            {
                product.ModifiedAt = DateTime.Now;
                await _genericProductRepository.Update(product);
                return product;
            }

            await _genericProductRepository.CreateAsync(product);

            return product;
        }

        public async Task<Data.Product> GetProductById(Guid id)
        {
            return await _genericProductRepository.GetById(id);
        }

        public async Task SaveAsync()
        {
            await _genericProductRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Data.Product>> GetBulkProductContent(IEnumerable<Guid> productIds)
        {
            return await _genericProductRepository.Filter(q => productIds.Contains(q.Id));
        }

        public async Task<IEnumerable<Data.Product>> GetAll()
        {
            return await _genericProductRepository.Filter(q => !q.IsDeleted);
        }
    }
}