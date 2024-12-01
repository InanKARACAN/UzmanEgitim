using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class KurumRepository : Repository<Kurum>, IKurumRepository
    {
        public KurumRepository(SqlDbContext context) : base(context)
        {
        }
    }
}