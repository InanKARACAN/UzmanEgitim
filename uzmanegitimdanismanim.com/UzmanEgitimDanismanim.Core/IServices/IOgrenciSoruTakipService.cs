using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Responses;
using UzmanEgitimDanismanim.Shared.ViewModels;

namespace UzmanEgitimDanismanim.Core.IServices
{
    public interface IOgrenciSoruTakipService : IService<OgrenciSoruTakip, OgrenciSoruTakipDto>
    {
        Task<PagedModel<OgrenciSoruTakipDto>> OgrenciSoruTakipGetir(SoruTakipAraViewModel model);
        Task<List<OgrenciSoruTakipDto>> OgrenciSoruGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi);
        Task<List<OgrenciSoruTakipDto>> OgrenciSoruKonuGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi, string dersAdi);
    }
}