using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Core.IServices
{
    public interface IOgrenciKendiniDegerlendirmeService : IService<OgrenciKendiniDegerlendirme, OgrenciKendiniDegerlendirmeDto>
    {
        //Task<List<OgrenciDersTakipDto>> OgrenciDersTakipGetir(int ogrenciId, int sinifId);
    }
}