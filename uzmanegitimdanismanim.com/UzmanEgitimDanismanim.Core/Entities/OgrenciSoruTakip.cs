namespace UzmanEgitimDanismanim.Core.Entities
{
    public class OgrenciSoruTakip : BaseEntity
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public Kullanici Ogrenci { get; set; }
        public int SinifDersKonuId { get; set; }
        public SinifDersKonu SinifDersKonu { get; set; }
        public DateTime CozumTarihi { get; set; }
        public int Adet { get; set; }
    }
}