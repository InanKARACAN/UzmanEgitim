using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UzmanEgitimDanismanim.Shared.Responses;

namespace UzmanEgitimDanismanim.Service.Extensions
{
    public static class DataPagerExtension
    {
        public static async Task<PagedModel<TModel>> PaginateAsync<TModel>(this IQueryable<TModel> query, int page, int limit)
            where TModel : class
        {

            var paged = new PagedModel<TModel>();

            page = page < 0 ? 1 : page;

            paged.CurrentPage = page;
            paged.PageSize = limit;

            paged.TotalItems = await query.CountAsync();

            var startRow = (page - 1) * limit;
            paged.Items = await query.Skip(startRow).Take(limit).ToListAsync();

            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

            return paged;
        }

        public static async Task<PagedModel<TDto>> PaginateAsync<TEntity, TDto>(this IQueryable<TEntity> query, int page, int limit, IMapper mapper)
            where TEntity : class where TDto : class
        {

            var paged = new PagedModel<TDto>();

            page = page < 0 ? 1 : page;

            paged.CurrentPage = page;
            paged.PageSize = limit;

            paged.TotalItems = await query.CountAsync();

            var startRow = (page - 1) * limit;
            var data = await query.Skip(startRow).Take(limit).ToListAsync();

            paged.Items = mapper.Map<List<TDto>>(data);

            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

            return paged;
        }
    }
}
