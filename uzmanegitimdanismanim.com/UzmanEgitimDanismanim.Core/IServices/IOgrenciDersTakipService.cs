using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Responses;
using UzmanEgitimDanismanim.Shared.ViewModels;

namespace UzmanEgitimDanismanim.Core.IServices
{
    public interface IOgrenciDersTakipService : IService<OgrenciDersTakip, OgrenciDersTakipDto>
    {
        Task<PagedModel<OgrenciDersTakipDto>> OgrenciDersTakipGetir(DersTakipAraViewModel model);
        Task<List<OgrenciDersTakipDto>> OgrenciDersGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi);
        Task<List<OgrenciDersTakipDto>> OgrenciDersKonuGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi, string dersAdi);
    }
}