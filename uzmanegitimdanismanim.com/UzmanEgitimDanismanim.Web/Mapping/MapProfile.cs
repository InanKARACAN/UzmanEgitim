using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Web.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<KullaniciDto, Kullanici>();
            CreateMap<Kullanici, KullaniciDto>()
                .ForMember(dest => dest.RolAdi, opt => opt.MapFrom(src => src.KullaniciRol.RolAdi));

            CreateMap<KullaniciRolDto, KullaniciRol>().ReverseMap();

            CreateMap<KurumDto, KurumDto>().ReverseMap();

            CreateMap<OgrenciDokumanDto, OgrenciDokuman>().ReverseMap();

            CreateMap<OgrenciDersTakipDto, OgrenciDersTakip>().ReverseMap();

            CreateMap<OgrenciSoruTakipDto, OgrenciSoruTakip>().ReverseMap();

            CreateMap<OgrenciSinavTakipDto, OgrenciSinavTakip>().ReverseMap();

            CreateMap<OgrenciSinavTakipCozum, OgrenciSinavTakipCozumDto>()
                .ForMember(dest => dest.Net, opt => opt.MapFrom(src => (src.Dogru-((decimal)src.Yanlis/4))))
                .ForMember(dest => dest.Net3, opt => opt.MapFrom(src => (src.Dogru-((decimal)src.Yanlis/3))));
            CreateMap<OgrenciSinavTakipCozumDto, OgrenciSinavTakipCozum>();
                
            CreateMap<OgrenciGorevTakipDto, OgrenciGorevTakip>().ReverseMap();

            CreateMap<OgrenciSinifDto, OgrenciSinif>();
            CreateMap<OgrenciSinif, OgrenciSinifDto>()
                .ForMember(dest => dest.SinifAdi, opt => opt.MapFrom(src => src.Sinif.SinifAdi));


            CreateMap<SinavDto, Sinav>().ReverseMap();

            CreateMap<SinavDersDto, SinavDers>().ReverseMap();

            CreateMap<SinavDersKonuDto, SinavDersKonu>().ReverseMap();

            CreateMap<SinifDto, Sinif>().ReverseMap();

            CreateMap<SinifDersDto, SinifDers>().ReverseMap();

            CreateMap<SinifDersKonuDto, SinifDersKonu>().ReverseMap();

            CreateMap<VeliOgrenciDto, VeliOgrenci>().ReverseMap();

            CreateMap<OgrenciEnvanteriHollandDto, OgrenciEnvanteriHolland>().ReverseMap();

            CreateMap<OgrenciKendiniDegerlendirmeDto, OgrenciKendiniDegerlendirme>().ReverseMap();

            CreateMap<DanismanOgrenciDto, DanismanOgrenci>().ReverseMap();


            //CreateMap<SatisDto, Satis>()
            //    .ForMember(dest => dest.SertifikaKurum, opt => opt.MapFrom(src => (SertifikaKurumEnum)src.SertifikaKurum))
            //    .ForMember(dest => dest.SatisYontemi, opt => opt.MapFrom(src => (SatisYontemiEnum)src.SertifikaKurum));
            //CreateMap<Satis, SatisDto>()
            //    .ForMember(dest => dest.SertifikaKurum, opt => opt.MapFrom(src => (int)src.SertifikaKurum))
            //    .ForMember(dest => dest.SertifikaKurumAciklama, opt => opt.MapFrom(src => EnumUtilsExt.GetDescriptionById<SertifikaKurumEnum>(EnumUtilsExt.GetEnumNumber<SertifikaKurumEnum>(src.SertifikaKurum))))
            //    .ForMember(dest => dest.SatisYontemi, opt => opt.MapFrom(src => (int)src.SatisYontemi))
            //    .ForMember(dest => dest.SatisYontemiAciklama, opt => opt.MapFrom(src => EnumUtilsExt.GetDescriptionById<SatisYontemiEnum>(EnumUtilsExt.GetEnumNumber<SatisYontemiEnum>(src.SatisYontemi))));

            //CreateMap<SatisOdemeDto, SatisOdeme>().ReverseMap();


            //CreateMap<ReklamDto, Reklam>()
            //    .ForMember(dest => dest.Kategori, opt => opt.MapFrom(src => (ReklamKategoriEnum)src.Kategori))
            //    .ForMember(dest => dest.Durum, opt => opt.MapFrom(src => (ReklamDurumEnum)src.Durum));

            //CreateMap<Reklam, ReklamDto>()
            //    .ForMember(dest => dest.Kategori, opt => opt.MapFrom(src => (int)src.Kategori))
            //    .ForMember(dest => dest.KategoriAciklama, opt => opt.MapFrom(src => EnumUtilsExt.GetDescriptionById<ReklamKategoriEnum>(EnumUtilsExt.GetEnumNumber<ReklamKategoriEnum>(src.Kategori))))
            //    .ForMember(dest => dest.Durum, opt => opt.MapFrom(src => (int)src.Durum))
            //    .ForMember(dest => dest.DurumAciklama, opt => opt.MapFrom(src => EnumUtilsExt.GetDescriptionById<ReklamDurumEnum>(EnumUtilsExt.GetEnumNumber<ReklamDurumEnum>(src.Durum))));


            ////CreateMap<KisiDto, TblKisi>().ReverseMap();
            ////CreateMap<TblKisi, KisiDto>().ForMember(dest => dest.KisiRoller, opt => opt.MapFrom(src => src.KisiRoller.Select(s => s.Rol)))
            ////                             .ForMember(dest => dest.KisiMenuler, opt => opt.MapFrom(src => src.KisiMenuler.Select(s => s.Menu)));
            //////.ForMember(dest => dest.KisiMenuler, opt => opt.MapFrom(src => src.KisiMenuler.Select(s => s.Menu)))

            ////CreateMap<UyeDto, TblUye>().ReverseMap();
            ////CreateMap<TblUye, UyeDto>().ForMember(dest => dest.Kisi_Id, opt => opt.MapFrom(src => src.Kisi.Id));



        }
    }
}
