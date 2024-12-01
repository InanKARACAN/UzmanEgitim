using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class SinifRepository : Repository<Sinif>, ISinifRepository
    {
        public SinifRepository(SqlDbContext context) : base(context)
        {
        }
    }
}