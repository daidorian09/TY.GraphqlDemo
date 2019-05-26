using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TY.GraphQL.Application.Product.Interfaces
{
    public interface IProductManager
    {
        Task<Data.Product> CreateProductAsync(Data.Product product);
        Task<Data.Product> GetProductById(Guid id);
        Task<IEnumerable<Data.Product>> GetBulkProductContent(IEnumerable<Guid> productIds);
        Task<IEnumerable<Data.Product>> GetAll();

    }
}