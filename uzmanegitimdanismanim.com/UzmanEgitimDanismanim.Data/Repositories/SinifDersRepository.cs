using Microsoft.EntityFrameworkCore;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class SinifDersRepository : Repository<SinifDers>, ISinifDersRepository
    {
        public SinifDersRepository(SqlDbContext context) : base(context)
        {
        }

        public async Task<List<SinifDers>> SinifDersleriGetir(int sinifId)
        {
            var sonuc = await _context.SinifDersler.Where(x => x.SinifId==sinifId).OrderBy(o=> o.SinifDersAdi).ToListAsync();
            return sonuc;
        }
    }
}