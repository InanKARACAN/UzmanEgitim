using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
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
    public class DanismanOgrenciService : Service<DanismanOgrenci, DanismanOgrenciDto>, IDanismanOgrenciService
    {

        public DanismanOgrenciService(IUnitOfWork unitOfWork, IRepository<DanismanOgrenci> danismanOgrenciRepository, IMapper mapper) : base(unitOfWork, danismanOgrenciRepository, mapper)
        {
        }

        public async Task<PagedModel<DanismanOgrenciDto>> DanismanOgrencileriGetir(OgrenciListeleAraViewModel model)
        {
            var predicate = PredicateHelper.True<DanismanOgrenci>();

            predicate = predicate.And(x => x.DanismanId == model.DanismanID && x.Silindi == false && x.Ogrenci.Silindi == false && x.Aktif == true);

            if (model.Ad != null)
            {
                predicate = predicate.And(x => x.Ogrenci.Ad.Contains(model.Ad.ToUpper(new CultureInfo("tr-TR", false))));
            }

            if (model.Soyad != null)
            {
                predicate = predicate.And(x => x.Ogrenci.Soyad.Contains(model.Soyad.ToUpper(new CultureInfo("tr-TR", false))));
            }

            var sonuc = await _unitOfWork.DanismanOgrenciler.DanismanOgrencileriGetir()
                .Where(predicate)
                .OrderByDescending(o => o.Ogrenci.Ad).ThenBy(t=> t.Ogrenci.Soyad)
                .PaginateAsync<DanismanOgrenci, DanismanOgrenciDto>(model.request.Page, model.request.PageSize, _mapper);
            return sonuc;
        }

        public async Task<PagedModel<DanismanOgrenciDto>> KurumOgrencileriGetir(OgrenciListeleAraViewModel model)
        {
            var predicate = PredicateHelper.True<DanismanOgrenci>();

            predicate = predicate.And(x => x.Ogrenci.KurumId == model.KurumID && x.Silindi == false && x.Ogrenci.Silindi == false && x.Aktif == true);

            if (model.Ad != null)
            {
                predicate = predicate.And(x => x.Ogrenci.Ad.Contains(model.Ad.ToUpper(new CultureInfo("tr-TR", false))));
            }

            if (model.Soyad != null)
            {
                predicate = predicate.And(x => x.Ogrenci.Soyad.Contains(model.Soyad.ToUpper(new CultureInfo("tr-TR", false))));
            }

            var sonuc = await _unitOfWork.DanismanOgrenciler.DanismanOgrencileriGetir()
                .Where(predicate)
                .OrderByDescending(o => o.Ogrenci.Ad).ThenBy(t => t.Ogrenci.Soyad)
                .PaginateAsync<DanismanOgrenci, DanismanOgrenciDto>(model.request.Page, model.request.PageSize, _mapper);
            return sonuc;
        }

        public async Task<DanismanOgrenciDto> OgrenciDanismaniGetir(int ogrenciId)
        {
            var sonuc = await _unitOfWork.DanismanOgrenciler.OgrenciDanismaniGetir()
                .Where(w=> w.OgrenciId==ogrenciId)
                .FirstOrDefaultAsync();
            return _mapper.Map<DanismanOgrenciDto>(sonuc);
        }
    }
}