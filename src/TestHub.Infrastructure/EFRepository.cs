using Microsoft.EntityFrameworkCore;
using TestHub.Core.Entities;
using TestHub.Core.Interfaces;
using TestHub.Infrastructure.Data;
using System.Linq.Expressions;

namespace TestHub.Infrastructure
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly TestHubContext _context;
        private readonly DbSet<TEntity> _entities;

        public EFRepository(TestHubContext context) //TODO Add logging
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(object id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _entities.Remove(entity);
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
