using Microsoft.EntityFrameworkCore;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.Helpers;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class OgrenciSoruTakipRepository : Repository<OgrenciSoruTakip>, IOgrenciSoruTakipRepository
    {
        public OgrenciSoruTakipRepository(SqlDbContext context) : base(context)
        {
        }

        public IQueryable<OgrenciSoruTakip> OgrenciSoruTakipGetir()
        {
            var sonuc = _context.OgrenciSoruTakipler
                .Include(i => i.SinifDersKonu).ThenInclude(t => t.SinifDers)
               .AsQueryable();
            return sonuc;
        }

        public async Task<List<OgrenciSoruTakip>> OgrenciSoruGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi)
        {
            var predicate = PredicateHelper.True<OgrenciSoruTakip>();

            predicate = predicate.And(x => x.OgrenciId == ogrenciId && x.SinifDersKonu.SinifDers.Sinif.Id == sinifId && x.Silindi == false && x.Aktif == true);

            if (baslangicTarihi != null)
            {
                predicate = predicate.And(x => x.CozumTarihi >= baslangicTarihi);
            }

            if (bitisTarihi != null)
            {
                predicate = predicate.And(x => x.CozumTarihi <= bitisTarihi);
            }

            var sonuc = await _context.OgrenciSoruTakipler
                .Include(i => i.SinifDersKonu).ThenInclude(t => t.SinifDers)
                .Where(predicate)
                .OrderByDescending(o => o.CozumTarihi)
                .ToListAsync();
            return sonuc;
        }

        public async Task<List<OgrenciSoruTakip>> OgrenciSoruKonuGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi, string dersAdi)
        {
            var predicate = PredicateHelper.True<OgrenciSoruTakip>();

            predicate = predicate.And(x =>x.SinifDersKonu.SinifDers.SinifDersAdi==dersAdi && x.OgrenciId == ogrenciId && x.SinifDersKonu.SinifDers.Sinif.Id == sinifId && x.Silindi == false && x.Aktif == true);

            if (baslangicTarihi != null)
            {
                predicate = predicate.And(x => x.CozumTarihi >= baslangicTarihi);
            }

            if (bitisTarihi != null)
            {
                predicate = predicate.And(x => x.CozumTarihi <= bitisTarihi);
            }

            var sonuc = await _context.OgrenciSoruTakipler
                .Include(i => i.SinifDersKonu).ThenInclude(t => t.SinifDers)
                .Where(predicate)
                .OrderByDescending(o => o.CozumTarihi)
                .ToListAsync();
            return sonuc;
        }
    }
}