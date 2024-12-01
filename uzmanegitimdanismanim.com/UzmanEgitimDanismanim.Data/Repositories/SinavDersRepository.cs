using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class SinavDersRepository : Repository<SinavDers>, ISinavDersRepository
    {
        public SinavDersRepository(SqlDbContext context) : base(context)
        {
        }
    }
}