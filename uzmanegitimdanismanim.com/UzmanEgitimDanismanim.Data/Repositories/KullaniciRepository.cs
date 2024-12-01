using Microsoft.EntityFrameworkCore;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Shared.Dtos.CustomDtos;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(SqlDbContext context) : base(context)
        {
        }

        public Task<Kullanici> GirisYap(LoginDto loginDto)
        {
            var kisi = _context.Kullanicilar
                .Include(i => i.KullaniciRol)
                .FirstOrDefaultAsync(f => f.Eposta == loginDto.Email 
                && f.Sifre == loginDto.Password && f.Silindi == false && f.Aktif== true
                && f.UyelikBitisTarihi >= DateTime.Now);
            return kisi;
        }


        public IQueryable<Kullanici> OgrenciGetir()
        {
            var sonuc = _context.Kullanicilar
                .Include(i => i.OgrenciDokumanlar)
                //.Include(i => i.OgrenciDersTakipler)
                //.Include(i => i.OgrenciSoruTakipler)
                //.Include(i => i.OgrenciGorevTakipler)
               .AsQueryable();
            return sonuc;
        }


        //public Task<Kullanici> KullaniciBilgileriGetir(int kullniciId)
        //{
        //    var kisi = _context.Kullanicilar
        //        .Include(i => i.KullaniciVideolar).ThenInclude(t => t.Video)
        //        .FirstOrDefaultAsync(f => f.Id == kullniciId);
        //    return kisi;
        //}

        //public Task<List<Kullanici>> KullaniciListele(int kurumId)
        //{
        //    var kullanicilar = _context.Kullanicilar
        //        .Include(i => i.KullaniciRol)
        //        .Include(i => i.Kurum)
        //        .Where(w => w.KurumId == kurumId)
        //        .ToListAsync();
        //    return kullanicilar;
        //}

        //public Task<List<Kullanici>> EgitmenListele()
        //{
        //    var kullanicilar = _context.Kullanicilar
        //        .Where(w => w.KullaniciRolId == 6)
        //        .ToListAsync();
        //    return kullanicilar;
        //}

        //public Task<List<Kullanici>> OgrenciListele(int kurumId)
        //{
        //    var kullanicilar = _context.Kullanicilar
        //        .Where(w => w.Aktif == true && w.KullaniciRolId == 7 && w.KurumId == kurumId)
        //        .ToListAsync();
        //    return kullanicilar;
        //}

        //public Task<List<Kullanici>> SatisYapanPersonelListele(int kurumId)
        //{
        //    var kullanicilar = _context.Kullanicilar
        //        .Where(w => w.Aktif == true && w.KullaniciRolId == 5 && w.KurumId == kurumId)
        //        .ToListAsync();
        //    return kullanicilar;
        //}
    }
}