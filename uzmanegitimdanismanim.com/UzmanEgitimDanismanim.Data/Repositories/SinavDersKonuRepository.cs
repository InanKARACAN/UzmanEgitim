using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class SinavDersKonuRepository : Repository<SinavDersKonu>, ISinavDersKonuRepository
    {
        public SinavDersKonuRepository(SqlDbContext context) : base(context)
        {
        }
    }
}