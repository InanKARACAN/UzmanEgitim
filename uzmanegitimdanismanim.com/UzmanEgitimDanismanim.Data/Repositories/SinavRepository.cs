using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class SinavRepository : Repository<Sinav>, ISinavRepository
    {
        public SinavRepository(SqlDbContext context) : base(context)
        {
        }
    }
}