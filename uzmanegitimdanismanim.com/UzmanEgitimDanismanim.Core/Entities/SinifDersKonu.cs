namespace UzmanEgitimDanismanim.Core.Entities
{
    public class SinifDersKonu : BaseEntity
    {
        public int Id { get; set; }
        public int SinifDersId { get; set; }
        public SinifDers SinifDers { get; set; }
        public string SinifDersKonuAdi { get; set; }
        public ICollection<OgrenciDersTakip> OgrenciDersTakipler { get; set; }
        public ICollection<OgrenciSoruTakip> OgrenciSoruTakipler { get; set; }
    }
}