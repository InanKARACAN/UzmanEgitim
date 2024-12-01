using Microsoft.EntityFrameworkCore;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class OgrenciSinavTakipRepository : Repository<OgrenciSinavTakip>, IOgrenciSinavTakipRepository
    {
        public OgrenciSinavTakipRepository(SqlDbContext context) : base(context)
        {
        }

        public IQueryable<OgrenciSinavTakip> OgrenciSinavTakipGetir()
        {
            var sonuc = _context.OgrenciSinavTakipler
               .Include(i => i.OgrenciSinavTakipCozumler).ThenInclude(t => t.SinavDers)
               .Include(i => i.Sinav)
               .AsQueryable();
            return sonuc;
        }
    }
}