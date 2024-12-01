using Microsoft.EntityFrameworkCore;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class SinifDersKonuRepository : Repository<SinifDersKonu>, ISinifDersKonuRepository
    {
        public SinifDersKonuRepository(SqlDbContext context) : base(context)
        {
        }

        public async Task<List<SinifDersKonu>> SinifDersKonulariGetir(int sinifDersId)
        {
            var sonuc = await _context.SinifDersKonular.Where(x => x.SinifDersId == sinifDersId).OrderBy(o => o.SinifDersKonuAdi).ToListAsync();
            return sonuc;
        }
    }
}