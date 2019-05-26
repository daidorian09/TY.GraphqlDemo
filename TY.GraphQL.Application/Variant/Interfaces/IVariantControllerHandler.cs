using System;
using System.Threading.Tasks;
using TY.GraphQL.Application.Variant.Models;

namespace TY.GraphQL.Application.Variant.Interfaces
{
    public interface IVariantControllerHandler
    {
        Task<Data.Variant> CreateVariantAsync (VariantViewModel model);
        Task<Data.Variant> GetVariantByIdAsync (Guid id);
    }
}