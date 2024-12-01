using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Core.IServices
{
    public interface IOgrenciSinifService : IService<OgrenciSinif, OgrenciSinifDto>
    {
        Task<List<OgrenciSinifDto>> OgrenciSiniflariGetir(int ogrenciId);
    }
}