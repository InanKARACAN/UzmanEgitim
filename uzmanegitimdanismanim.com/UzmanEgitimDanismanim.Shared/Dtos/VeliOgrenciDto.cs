namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class VeliOgrenciDto : BaseDto, IDto
    {
        public int VeliId { get; set; }
        public int OgrenciId { get; set; }
        public KullaniciDto Ogrenci { get; set; }
    }
}
