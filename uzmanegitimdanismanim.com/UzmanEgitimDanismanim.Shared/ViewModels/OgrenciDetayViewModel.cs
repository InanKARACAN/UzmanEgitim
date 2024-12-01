using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Dtos.CustomDtos;

namespace UzmanEgitimDanismanim.Shared.ViewModels
{
    public class OgrenciDetayViewModel
    {
        public OgrenciDetayViewModel()
        {
            GorevListesi = new List<CalenderDto>();
        //    UyelikBilgileri = new List<UyelikBilgileriDto>();
        //    VeliIzinleri = new List<VeliIzinDto>();
        //    OgrenimVM = new UyeGuncelleOgrenimViewModel();
        }
        public KullaniciDto Ogrenci { get; set; }
        public List<CalenderDto> GorevListesi { get; set; }
        public SinavTakipViewModel SinavTakipViewModel { get; set; }
        //public List<UyeTarihceDto> Tarihce { get; set; }
        //public List<UyelikBilgileriDto> UyelikBilgileri { get; set; }
        //public List<VeliIzinDto> VeliIzinleri { get; set; }
        //public UyeGuncelleOgrenimViewModel OgrenimVM { get; set; }
    }
}