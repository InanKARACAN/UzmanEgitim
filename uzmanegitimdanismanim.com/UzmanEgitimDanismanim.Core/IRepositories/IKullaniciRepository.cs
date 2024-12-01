using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos.CustomDtos;

namespace UzmanEgitimDanismanim.Core.IRepositories
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        Task<Kullanici> GirisYap(LoginDto loginDto);
        //IQueryable<Kullanici> OgrenciListesiGetir();
        IQueryable<Kullanici> OgrenciGetir();

        //Task<Kullanici> KullaniciBilgileriGetir(int kullniciId);
        //Task<List<Kullanici>> KullaniciListele(int kurumId);
        //Task<List<Kullanici>> EgitmenListele();
        //Task<List<Kullanici>> OgrenciListele(int kurumId);
        //Task<List<Kullanici>> SatisYapanPersonelListele(int kurumId);
    }
}
