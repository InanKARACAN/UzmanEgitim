using UzmanEgitimDanismanim.Shared.Enums;

namespace UzmanEgitimDanismanim.Core.Entities
{
    public class OgrenciGorevTakip : BaseEntity
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public Kullanici Ogrenci { get; set; }
        public string Baslik { get; set; }
        public DateTime GorevBaslangic { get; set; }
        public DateTime GorevBitis { get; set; }
        public bool TumGun { get; set; }
        public bool Silinebilir { get; set; }
        public GorevTakipDurumEnum Durum { get; set; }
    }
}