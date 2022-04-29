using Dukkantek.Domain.Base;
using Dukkantek.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet = null;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }
        public async Task AddRangeAsync(List<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
        public async Task<bool> AnyAsync()
        {
            return await _dbSet.AnyAsync();
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.AnyAsync(where);
        }

        public async Task<TEntity> FindByExpressionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.AsNoTracking().Where(where).ToListAsync();
        }

        public async Task<bool> RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            var result = await _dbContext.SaveChangesAsync();
            return (result > 0) ? true : false;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null) return null;
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
