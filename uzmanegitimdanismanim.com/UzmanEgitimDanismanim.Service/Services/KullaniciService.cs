using AutoMapper;
using System.Globalization;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.Helpers;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Service.Extensions;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Dtos.CustomDtos;
using UzmanEgitimDanismanim.Shared.Responses;
using UzmanEgitimDanismanim.Shared.ViewModels;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class KullaniciService : Service<Kullanici, KullaniciDto>, IKullaniciService
    {

        public KullaniciService(IUnitOfWork unitOfWork, IRepository<Kullanici> kullaniciRepository, IMapper mapper) : base(unitOfWork, kullaniciRepository, mapper)
        {
        }

        public async Task<GResponse<KullaniciDto>> GirisYap(LoginDto loginDto)
        {
            var kullanici = await _unitOfWork.Kullanicilar.GirisYap(loginDto);
            return new GResponse<KullaniciDto>(_mapper.Map<KullaniciDto>(kullanici));
        }

//        public async Task<PagedModel<KullaniciDto>> OgrenciListesiGetir(OgrenciListeleAraViewModel model)
//        {
//            var predicate = PredicateHelper.True<Kullanici>();

//            //predicate = predicate.And(x => x.KullaniciRol == model.OgrenciId && x.SinifDersKonu.SinifDers.Sinif.Id == model.SinifId && x.Silindi == false && x.Aktif == true);

//            predicate = predicate.And(x => x.KullaniciRolId == 7);
//            //var d = await _unitOfWork.DanismanOgrenciler.Where(w => w.DanismanId == model.DanismanID);

//            //predicate = predicate.And(x => _unitOfWork.DanismanOgrenciler.Where(w => w.DanismanId == model.DanismanID));
//            //predicate = predicate.And(x => x.DanismanOgrenciler.Where(w=> w.DanismanId==model.DanismanID).Any());


////             && x.DanismanOgrenciler.Where(w => w.DanismanId == model.DanismanID)


//            if (model.Ad != null)
//            {
//                predicate = predicate.And(x => x.Ad.Contains(model.Ad.ToUpper(new CultureInfo("tr-TR", false))));
//            }

//            if (model.Soyad != null)
//            {
//                predicate = predicate.And(x => x.Soyad.Contains(model.Soyad.ToUpper(new CultureInfo("tr-TR", false))));

//            }

//            var sonuc = await _unitOfWork.Kullanicilar.OgrenciListesiGetir()
//                .Where(predicate)
//                .Join((await _unitOfWork.DanismanOgrenciler.Where(w => w.DanismanId == model.DanismanID)),f => f.Id, s => s.DanismanId,
//                (f, s) =>
//                new Kullanici
//                {
//                    Ad = f.Ad,
//                    Soyad = f.Soyad,
//                    Id = f.Id
//                })
//                .OrderBy(o => o.Ad)
//                .PaginateAsync<Kullanici, KullaniciDto>(model.request.Page, model.request.PageSize, _mapper);
//            return sonuc;
//        }

        public async Task<GResponse<KullaniciDto>> OgrenciGetir(int id)
        {
            var sonuc = _unitOfWork.Kullanicilar.OgrenciGetir()
                .Where(x => x.Id == id && x.Silindi == false)
                .FirstOrDefault();
            return new GResponse<KullaniciDto>(_mapper.Map<KullaniciDto>(sonuc));
        }

        //public async Task<GResponse<KullaniciDto>> KullaniciBilgileriGetir(int kullniciId)
        //{
        //    var kullanici = await _unitOfWork.Kullanicilar.KullaniciBilgileriGetir(kullniciId);
        //    return new GResponse<KullaniciDto>(_mapper.Map<KullaniciDto>(kullanici));
        //}

        //public async Task<GResponse<List<KullaniciDto>>> KullaniciListele(int kurumId)
        //{
        //    var kullanicilar = await _unitOfWork.Kullanicilar.KullaniciListele(kurumId);
        //    return new GResponse<List<KullaniciDto>>(_mapper.Map<List<KullaniciDto>>(kullanicilar));
        //}

        //public async Task<GResponse<List<KullaniciDto>>> EgitmenListele()
        //{
        //    var kullanicilar = await _unitOfWork.Kullanicilar.EgitmenListele();
        //    return new GResponse<List<KullaniciDto>>(_mapper.Map<List<KullaniciDto>>(kullanicilar));
        //}

        //public async Task<GResponse<List<KullaniciDto>>> OgrenciListele(int kurumId)
        //{
        //    var kullanicilar = await _unitOfWork.Kullanicilar.OgrenciListele(kurumId);
        //    return new GResponse<List<KullaniciDto>>(_mapper.Map<List<KullaniciDto>>(kullanicilar));
        //}

        //public async Task<GResponse<List<KullaniciDto>>> SatisYapanPersonelListele(int kurumId)
        //{
        //    var kullanicilar = await _unitOfWork.Kullanicilar.SatisYapanPersonelListele(kurumId);
        //    return new GResponse<List<KullaniciDto>>(_mapper.Map<List<KullaniciDto>>(kullanicilar));
        //}

    }
}