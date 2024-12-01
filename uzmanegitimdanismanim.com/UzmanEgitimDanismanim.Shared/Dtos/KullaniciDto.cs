using System.ComponentModel.DataAnnotations;

namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class KullaniciDto : BaseDto, IDto
    {
        public KullaniciDto()
        {
            UyelikBitisTarihi=DateTime.Now;
        }

        [Display(Name = "Sınıf")]
        public int SinifId { get; set; }
        public int KurumId { get; set; }
        public int KullaniciRolId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        [Display(Name = "Cep Telefonu")]
        public string CepTelefonu { get; set; }
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }
        public string RolAdi { get; set; }
        public bool EnvanterHollandYapildiMi { get; set; }
        public bool KendiniDegerlendirmeEnvanteriYapildiMi { get; set; }
        public DateTime UyelikBitisTarihi { get; set; }
        public List<OgrenciSinavTakipDto> OgrenciSinavTakipler { get; set; }
        public List<OgrenciDokumanDto> OgrenciDokumanlar { get; set; }
    }
}