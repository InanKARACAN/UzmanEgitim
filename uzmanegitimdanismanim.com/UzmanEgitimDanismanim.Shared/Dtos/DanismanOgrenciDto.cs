namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class DanismanOgrenciDto : BaseDto, IDto
    {
        public int DanismanId { get; set; }
        public int KurumId { get; set; }
        public int OgrenciId { get; set; }
        public KullaniciDto Ogrenci { get; set; }
    }
}
