using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Responses;
using UzmanEgitimDanismanim.Shared.ViewModels;

namespace UzmanEgitimDanismanim.Core.IServices
{
    public interface IDanismanOgrenciService : IService<DanismanOgrenci, DanismanOgrenciDto>
    {
        Task<PagedModel<DanismanOgrenciDto>> DanismanOgrencileriGetir(OgrenciListeleAraViewModel model);
        Task<PagedModel<DanismanOgrenciDto>> KurumOgrencileriGetir(OgrenciListeleAraViewModel model);
        Task<DanismanOgrenciDto> OgrenciDanismaniGetir(int ogrenciID);
    }
}