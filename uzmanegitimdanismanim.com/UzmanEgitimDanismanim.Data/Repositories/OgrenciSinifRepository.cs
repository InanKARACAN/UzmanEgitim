using Microsoft.EntityFrameworkCore;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class OgrenciSinifRepository : Repository<OgrenciSinif>, IOgrenciSinifRepository
    {
        public OgrenciSinifRepository(SqlDbContext context) : base(context)
        {
        }

        public async Task<List<OgrenciSinif>> OgrenciSiniflariGetir(int ogrenciId)
        {
            var sonuc = await _context.OgrenciSiniflar
                .Include(i => i.Sinif)
                .Where(x => x.OgrenciId == ogrenciId).ToListAsync();
            return sonuc;
        }
    }
}