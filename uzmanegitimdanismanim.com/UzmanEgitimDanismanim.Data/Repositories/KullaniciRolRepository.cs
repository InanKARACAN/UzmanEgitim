using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class KullaniciRolRepository : Repository<KullaniciRol>, IKullaniciRolRepository
    {
        public KullaniciRolRepository(SqlDbContext context) : base(context)
        {
        }
    }
}