using Microsoft.EntityFrameworkCore;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class OgrenciKendiniDegerlendirmeRepository : Repository<OgrenciKendiniDegerlendirme>, IOgrenciKendiniDegerlendirmeRepository
    {
        public OgrenciKendiniDegerlendirmeRepository(SqlDbContext context) : base(context)
        {
        }

        //public async Task<List<OgrenciDersTakip>> OgrenciDersTakipGetir(int ogrenciId, int sinifId)
        //{
        //    var sonuc = await _context.OgrenciDersTakipler
        //        .Include(i => i.SinifDersKonu).ThenInclude(t => t.SinifDers)
        //        .Where(x => x.OgrenciId == ogrenciId  && x.SinifDersKonu.SinifDers.Sinif.Id == sinifId && x.Silindi==false && x.Aktif==true)
        //        .OrderByDescending(o => o.CalismaTarihi)
        //        .ToListAsync();
        //    return sonuc;
        //}
    }
}