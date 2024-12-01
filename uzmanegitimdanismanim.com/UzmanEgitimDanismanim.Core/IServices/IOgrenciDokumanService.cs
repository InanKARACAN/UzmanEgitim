using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Core.IServices
{
    public interface IOgrenciDokumanService : IService<OgrenciDokuman, OgrenciDokumanDto>
    {
        List<OgrenciDokumanDto> OgrenciDokumanGetir(int ogrenciId);
        //Task<List<OgrenciDersTakipDto>> OgrenciDersGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi);
    }
}