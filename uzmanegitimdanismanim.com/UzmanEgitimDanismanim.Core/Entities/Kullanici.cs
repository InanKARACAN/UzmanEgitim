namespace UzmanEgitimDanismanim.Core.Entities
{
    public class Kullanici : BaseEntity
    {
        public int Id { get; set; }
        public int KurumId { get; set; }
        public Kurum Kurum { get; set; }
        public int KullaniciRolId { get; set; }
        public KullaniciRol KullaniciRol { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string CepTelefonu { get; set; }
        public string Sifre { get; set; }
        public bool EnvanterHollandYapildiMi { get; set; }
        public bool KendiniDegerlendirmeEnvanteriYapildiMi { get; set; }
        public DateTime UyelikBitisTarihi { get; set; }
        public DateTime? SonGirisTarihi { get; set; }
        public ICollection<OgrenciDersTakip> OgrenciDersTakipler { get; set; }
        public ICollection<OgrenciSoruTakip> OgrenciSoruTakipler { get; set; }
        public ICollection<OgrenciGorevTakip> OgrenciGorevTakipler { get; set; }
        public ICollection<OgrenciEnvanteriHolland> OgrenciEnvanteriHollandlar { get; set; }
        public ICollection<OgrenciKendiniDegerlendirme> OgrenciKendiniDegerlendirmeler { get; set; }
        public ICollection<OgrenciDokuman> OgrenciDokumanlar { get; set; }
    }
}