using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.Extensions;
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
    public class OgrenciDersTakipService : Service<OgrenciDersTakip, OgrenciDersTakipDto>, IOgrenciDersTakipService
    {

        public OgrenciDersTakipService(IUnitOfWork unitOfWork, IRepository<OgrenciDersTakip> ogrenciDersTakipRepository, IMapper mapper) : base(unitOfWork, ogrenciDersTakipRepository, mapper)
        {
        }

        public async Task<PagedModel<OgrenciDersTakipDto>> OgrenciDersTakipGetir(DersTakipAraViewModel model)
        {
            var predicate = PredicateHelper.True<OgrenciDersTakip>();

            predicate = predicate.And(x => x.OgrenciId == model.OgrenciId && x.SinifDersKonu.SinifDers.Sinif.Id == model.SinifId && x.Silindi == false && x.Aktif == true);
            //

            if (model.BaslangicTarihi != null)
            {
                predicate = predicate.And(x => x.CalismaTarihi >= model.BaslangicTarihi);
            }

            if (model.BitisTarihi != null)
            {
                predicate = predicate.And(x => x.CalismaTarihi <= model.BitisTarihi);
            }

            var sonuc = await _unitOfWork.OgrenciDersTakipler.OgrenciDersTakipGetir()
                .Where(predicate)
                .OrderByDescending(o => o.CalismaTarihi)
                .PaginateAsync<OgrenciDersTakip, OgrenciDersTakipDto>(model.request.Page, model.request.PageSize, _mapper);
            return sonuc;
        }


        public async Task<List<OgrenciDersTakipDto>> OgrenciDersGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi)
        {
            var sonuc = await _unitOfWork.OgrenciDersTakipler.OgrenciDersGrafikGetir(ogrenciId, sinifId, baslangicTarihi, bitisTarihi);
            return _mapper.Map<List<OgrenciDersTakipDto>>(sonuc);
        }

        public async Task<List<OgrenciDersTakipDto>> OgrenciDersKonuGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi, string dersAdi)
        {
            var sonuc = await _unitOfWork.OgrenciDersTakipler.OgrenciDersKonuGrafikGetir(ogrenciId, sinifId, baslangicTarihi, bitisTarihi, dersAdi);
            return _mapper.Map<List<OgrenciDersTakipDto>>(sonuc);
        }

    }
}