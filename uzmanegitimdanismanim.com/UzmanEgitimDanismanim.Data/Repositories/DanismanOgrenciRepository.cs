using Microsoft.EntityFrameworkCore;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class DanismanOgrenciRepository : Repository<DanismanOgrenci>, IDanismanOgrenciRepository
    {
        public DanismanOgrenciRepository(SqlDbContext context) : base(context)
        {
        }

        public IQueryable<DanismanOgrenci> DanismanOgrencileriGetir()
        {
            var sonuc = _context.DanismanOgrenciler
                .Include(i => i.Ogrenci)
                .AsQueryable();
            return sonuc;
        }

        public IQueryable<DanismanOgrenci> OgrenciDanismaniGetir()
        {
            var sonuc = _context.DanismanOgrenciler
                .AsQueryable();
            return sonuc;
        }
    }
}