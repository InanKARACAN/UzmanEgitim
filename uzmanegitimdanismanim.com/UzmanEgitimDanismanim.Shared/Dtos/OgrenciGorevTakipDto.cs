using UzmanEgitimDanismanim.Shared.Enums;

namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class OgrenciGorevTakipDto : BaseDto, IDto
    {
        public int OgrenciId { get; set; }
        public string Baslik { get; set; }
        public DateTime GorevBaslangic { get; set; }
        public DateTime GorevBitis { get; set; }
        public bool TumGun { get; set; }
        public string BaslangicSaat { get; set; }
        public string BitisSaat { get; set; }
        public bool Silinebilir { get; set; }
        public GorevTakipDurumEnum Durum { get; set; }
    }
}