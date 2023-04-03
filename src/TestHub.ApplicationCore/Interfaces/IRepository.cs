using System.Linq.Expressions;
using TestHub.Core.Entities;

namespace TestHub.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
