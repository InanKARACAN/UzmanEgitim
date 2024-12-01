using Microsoft.EntityFrameworkCore;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class VeliOgrenciRepository : Repository<VeliOgrenci>, IVeliOgrenciRepository
    {
        public VeliOgrenciRepository(SqlDbContext context) : base(context)
        {
        }

        public async Task<List<VeliOgrenci>> VeliOgrencileriGetir(int veliId)
        {
            var sonuc = await _context.VeliOgrenciler.Where(x => x.VeliId == veliId)
                .Include(i => i.Ogrenci)
                .OrderBy(o => o.Ogrenci.Ad).ToListAsync();
            return sonuc;
        }
    }
}