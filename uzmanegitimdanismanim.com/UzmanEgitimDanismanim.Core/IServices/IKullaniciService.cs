using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Dtos.CustomDtos;
using UzmanEgitimDanismanim.Shared.Responses;
using UzmanEgitimDanismanim.Shared.ViewModels;

namespace UzmanEgitimDanismanim.Core.IServices
{
    public interface IKullaniciService : IService<Kullanici, KullaniciDto>
    {
        Task<GResponse<KullaniciDto>> GirisYap(LoginDto loginDto);
        //Task<PagedModel<KullaniciDto>> OgrenciListesiGetir(OgrenciListeleAraViewModel model);
        Task<GResponse<KullaniciDto>> OgrenciGetir(int id);

        //Task<GResponse<KullaniciDto>> KullaniciBilgileriGetir(int kullniciId);
        //Task<GResponse<List<KullaniciDto>>> KullaniciListele(int kurumId);
        //Task<GResponse<List<KullaniciDto>>> EgitmenListele();
        //Task<GResponse<List<KullaniciDto>>> OgrenciListele(int kurumId);
        //Task<GResponse<List<KullaniciDto>>> SatisYapanPersonelListele(int kurumId);
    }
}