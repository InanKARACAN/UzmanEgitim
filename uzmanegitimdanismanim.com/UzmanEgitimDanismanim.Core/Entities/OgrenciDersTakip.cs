namespace UzmanEgitimDanismanim.Core.Entities
{
    public class OgrenciDersTakip : BaseEntity
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public Kullanici Ogrenci { get; set; }
        public int SinifDersKonuId { get; set; }
        public SinifDersKonu SinifDersKonu { get; set; }
        public DateTime CalismaTarihi { get; set; }
        public int CalismaSuresi { get; set; }
    }
}