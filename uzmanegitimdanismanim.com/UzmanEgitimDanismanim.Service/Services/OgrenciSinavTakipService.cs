using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.Helpers;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Service.Extensions;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Responses;
using UzmanEgitimDanismanim.Shared.ViewModels;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class OgrenciSinavTakipService : Service<OgrenciSinavTakip, OgrenciSinavTakipDto>, IOgrenciSinavTakipService
    {

        public OgrenciSinavTakipService(IUnitOfWork unitOfWork, IRepository<OgrenciSinavTakip> ogrenciSinavTakipRepository, IMapper mapper) : base(unitOfWork, ogrenciSinavTakipRepository, mapper)
        {
        }

        public async Task<PagedModel<OgrenciSinavTakipDto>> OgrenciSinavTakipGetir(SinavTakipAraViewModel model)
        {
            var predicate = PredicateHelper.True<OgrenciSinavTakip>();

            predicate = predicate.And(x => x.OgrenciId == model.OgrenciId && x.Silindi == false && x.Aktif == true);

            if (model.BaslangicTarihi != null)
            {
                predicate = predicate.And(x => x.CozumTarihi >= model.BaslangicTarihi);
            }

            if (model.BitisTarihi != null)
            {
                predicate = predicate.And(x => x.CozumTarihi <= model.BitisTarihi);
            }

            var sonuc = await _unitOfWork.OgrenciSinavTakipler.OgrenciSinavTakipGetir()
                .Where(predicate)
                .OrderByDescending(o => o.CozumTarihi)
                .PaginateAsync<OgrenciSinavTakip, OgrenciSinavTakipDto>(model.request.Page, model.request.PageSize, _mapper);
            return sonuc;
        }
    }
}