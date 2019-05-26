using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TY.GraphQL.Data;

namespace TY.GraphQL.Persistence.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : IBaseEntity
    {
        #region Async Methods
         
        Task CreateAsync(TEntity entity);

        Task CreateBulkAsync(List<TEntity> entities);

        Task DeleteAsync(TEntity entity);

        Task DeleteByIdAsync(Guid id);

        Task Update(TEntity entity);

        Task<TEntity> GetById(Guid id);

        Task<IEnumerable<TEntity>> Filter(Func<TEntity, bool> predicate);

        Task SaveChangesAsync();

        #endregion
    }
}