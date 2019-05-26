using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TY.GraphQL.Data;
using TY.GraphQL.Persistence.Infrastructure;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;
namespace TY.GraphQL.Persistence
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        #region Fields

        private readonly GraphqlDemoDbContext _dbContext;

        #endregion

        #region Ctor

        public GenericRepository(GraphqlDemoDbContext dbContext) => _dbContext = dbContext;

        #endregion

        public async Task CreateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Set<TEntity>().Update(entity);
            await SaveChangesAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(q => q.Id.Equals(id));
        }

        public async Task<IEnumerable<TEntity>> Filter(Func<TEntity, bool> predicate)
        {
            var entities = _dbContext.Set<TEntity>().Where(predicate);
            return await Task.FromResult(entities.ToList());
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


        public async Task CreateBulkAsync(List<TEntity> entities)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
            await SaveChangesAsync();
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}