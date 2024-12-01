using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Responses;
using UzmanEgitimDanismanim.Shared.ViewModels;

namespace UzmanEgitimDanismanim.Core.IServices
{
    public interface IOgrenciSinavTakipService : IService<OgrenciSinavTakip, OgrenciSinavTakipDto>
    {
        Task<PagedModel<OgrenciSinavTakipDto>> OgrenciSinavTakipGetir(SinavTakipAraViewModel model);
    }
}