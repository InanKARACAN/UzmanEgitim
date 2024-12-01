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
    public class OgrenciSoruTakipService : Service<OgrenciSoruTakip, OgrenciSoruTakipDto>, IOgrenciSoruTakipService
    {

        public OgrenciSoruTakipService(IUnitOfWork unitOfWork, IRepository<OgrenciSoruTakip> ogrenciSoruTakipRepository, IMapper mapper) : base(unitOfWork, ogrenciSoruTakipRepository, mapper)
        {
        }

        public async Task<PagedModel<OgrenciSoruTakipDto>> OgrenciSoruTakipGetir(SoruTakipAraViewModel model)
        {
            var predicate = PredicateHelper.True<OgrenciSoruTakip>();

            predicate = predicate.And(x => x.OgrenciId == model.OgrenciId && x.SinifDersKonu.SinifDers.Sinif.Id == model.SinifId && x.Silindi == false && x.Aktif == true);
            //

            if (model.BaslangicTarihi != null)
            {
                predicate = predicate.And(x => x.CozumTarihi >= model.BaslangicTarihi);
            }

            if (model.BitisTarihi != null)
            {
                predicate = predicate.And(x => x.CozumTarihi <= model.BitisTarihi);
            }

            var sonuc = await _unitOfWork.OgrenciSoruTakipler.OgrenciSoruTakipGetir()
                .Where(predicate)
                .OrderByDescending(o => o.CozumTarihi)
                .PaginateAsync<OgrenciSoruTakip, OgrenciSoruTakipDto>(model.request.Page, model.request.PageSize, _mapper);
            return sonuc;
        }

        public async Task<List<OgrenciSoruTakipDto>> OgrenciSoruGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi)
        {
            var sonuc = await _unitOfWork.OgrenciSoruTakipler.OgrenciSoruGrafikGetir(ogrenciId, sinifId, baslangicTarihi, bitisTarihi);
            return _mapper.Map<List<OgrenciSoruTakipDto>>(sonuc);
        }

        public async Task<List<OgrenciSoruTakipDto>> OgrenciSoruKonuGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi, string dersAdi)
        {
            var sonuc = await _unitOfWork.OgrenciSoruTakipler.OgrenciSoruKonuGrafikGetir(ogrenciId, sinifId, baslangicTarihi, bitisTarihi, dersAdi);
            return _mapper.Map<List<OgrenciSoruTakipDto>>(sonuc);
        }
    }
}