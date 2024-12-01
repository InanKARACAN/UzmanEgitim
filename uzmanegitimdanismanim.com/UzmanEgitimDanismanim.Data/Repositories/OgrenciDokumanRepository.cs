using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class OgrenciDokumanRepository : Repository<OgrenciDokuman>, IOgrenciDokumanRepository
    {
        public OgrenciDokumanRepository(SqlDbContext context) : base(context)
        {
        }

        public IQueryable<OgrenciDokuman> OgrenciDokumanGetir()
        {
            var sonuc = _context.OgrenciDokumanlar
               .AsQueryable();
            return sonuc;
        }

    }
}