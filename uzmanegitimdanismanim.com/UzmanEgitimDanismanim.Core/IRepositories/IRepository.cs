using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace UzmanEgitimDanismanim.Core.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        long Count();

        Task<TEntity> GetByIdAsNoTrackingAsync(int id);

        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate, IList<string> includes = null);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, IList<string> includes = null);

        DbSet<TEntity> GetTable();
    }
}
