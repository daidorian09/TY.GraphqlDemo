using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TY.GraphQL.Application.Product.Models;

namespace TY.GraphQL.Application.Product.Interfaces
{
    public interface IProductControllerHandler
    {
        Task<Data.Product> CreateProductAsync (ProductViewModel model);
        Task<Data.Product> GetProductByIdAsync (Guid id);
        Task<IEnumerable<Data.Product>> GetAll();

    }

}