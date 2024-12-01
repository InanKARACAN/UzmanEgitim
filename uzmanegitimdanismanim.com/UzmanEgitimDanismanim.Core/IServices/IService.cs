using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Responses;

namespace UzmanEgitimDanismanim.Core.IServices
{
    public interface IService<TEntity, TDto> where TEntity : class, IEntity where TDto : class, IDto
    {
        Task<GResponse<TDto>> GetByIdWithResponseAsync(int id);
        Task<GResponse<IEnumerable<TDto>>> GetAllWithResponseAsync();
        Task<GResponse<IEnumerable<TDto>>> WhereWithResponse(Expression<Func<TEntity, bool>> predicate);
        Task<GResponse<TDto>> SingleOrDefaultWithResponseAsync(Expression<Func<TEntity, bool>> predicate);
        Task<GResponse<TDto>> AddWithResponseAsync(TEntity entity);
        Task<GResponse<IEnumerable<TDto>>> AddRangeWithResponseAsync(List<TEntity> entities);
        Task<GResponse<TDto>> RemoveWithResponseAsync(int id);
        GResponse<IEnumerable<TDto>> RemoveRangeReponse(IEnumerable<TEntity> entities);
        GResponse<TDto> UpdateWithResponse(TEntity entity);
        GResponse<DbSet<TEntity>> GetTableWithResponse();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByIdAsNoTrackingAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(List<TEntity> entities);
        Task<TEntity> Remove(int id);
        TEntity Update(TEntity entity);
        DbSet<TEntity> GetTable();
    }
}
