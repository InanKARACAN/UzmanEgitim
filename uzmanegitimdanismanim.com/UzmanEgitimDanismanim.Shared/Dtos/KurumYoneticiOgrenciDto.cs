namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class KurumYoneticiOgrenciDto : BaseDto, IDto
    {
        public int KurumId { get; set; }
        public int OgrenciId { get; set; }
        public KullaniciDto Ogrenci { get; set; }
    }
}
