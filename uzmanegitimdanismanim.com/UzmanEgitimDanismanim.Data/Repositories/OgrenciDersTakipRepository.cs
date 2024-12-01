using Microsoft.EntityFrameworkCore;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.Helpers;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class OgrenciDersTakipRepository : Repository<OgrenciDersTakip>, IOgrenciDersTakipRepository
    {
        public OgrenciDersTakipRepository(SqlDbContext context) : base(context)
        {
        }

        public IQueryable<OgrenciDersTakip> OgrenciDersTakipGetir()
        {
            var sonuc = _context.OgrenciDersTakipler
               .Include(i => i.SinifDersKonu).ThenInclude(t => t.SinifDers)
               //.Where(x => x.OgrenciId == ogrenciId && x.SinifDersKonu.SinifDers.Sinif.Id == sinifId && x.Silindi == false && x.Aktif == true)
               //.OrderByDescending(o => o.CalismaTarihi)
               .AsQueryable();
            return sonuc;
        }

        public async Task<List<OgrenciDersTakip>> OgrenciDersGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi)
        {
            var predicate = PredicateHelper.True<OgrenciDersTakip>();

            predicate = predicate.And(x => x.OgrenciId == ogrenciId && x.SinifDersKonu.SinifDers.Sinif.Id == sinifId && x.Silindi == false && x.Aktif == true);
            
            if (baslangicTarihi != null)
            {
                predicate = predicate.And(x => x.CalismaTarihi >= baslangicTarihi);
            }

            if (bitisTarihi != null)
            {
                predicate = predicate.And(x => x.CalismaTarihi <= bitisTarihi);
            }

            var sonuc = await _context.OgrenciDersTakipler
                .Include(i => i.SinifDersKonu).ThenInclude(t => t.SinifDers)
                .Where(predicate)
                .OrderByDescending(o => o.CalismaTarihi)
                .ToListAsync();
            return sonuc;
        }

        public async Task<List<OgrenciDersTakip>> OgrenciDersKonuGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi, string dersAdi)
        {
            var predicate = PredicateHelper.True<OgrenciDersTakip>();

            predicate = predicate.And(x => x.SinifDersKonu.SinifDers.SinifDersAdi==dersAdi && x.OgrenciId == ogrenciId && x.SinifDersKonu.SinifDers.Sinif.Id == sinifId && x.Silindi == false && x.Aktif == true);

            if (baslangicTarihi != null)
            {
                predicate = predicate.And(x => x.CalismaTarihi >= baslangicTarihi);
            }

            if (bitisTarihi != null)
            {
                predicate = predicate.And(x => x.CalismaTarihi <= bitisTarihi);
            }

            var sonuc = await _context.OgrenciDersTakipler
                .Include(i => i.SinifDersKonu)
                .Where(predicate)
                .OrderByDescending(o => o.CalismaTarihi)
                .ToListAsync();
            return sonuc;
        }
    }
}