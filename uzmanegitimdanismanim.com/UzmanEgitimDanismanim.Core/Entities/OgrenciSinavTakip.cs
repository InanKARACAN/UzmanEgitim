using UzmanEgitimDanismanim.Shared.Enums;

namespace UzmanEgitimDanismanim.Core.Entities
{
    public class OgrenciSinavTakip : BaseEntity
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public Kullanici Ogrenci { get; set; }
        public int SinavId { get; set; }
        public Sinav Sinav { get; set; }
        public string SinavAdi { get; set; }
        public SinavZorlukSeviyesiEnum ZorlukSeviyesi { get; set; }
        public DateTime CozumTarihi { get; set; }
        public ICollection<OgrenciSinavTakipCozum> OgrenciSinavTakipCozumler { get; set; }
    }
}