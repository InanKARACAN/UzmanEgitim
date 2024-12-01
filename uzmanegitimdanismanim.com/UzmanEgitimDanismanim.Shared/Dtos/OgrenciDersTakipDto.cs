namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class OgrenciDersTakipDto : BaseDto, IDto
    {
        public int OgrenciId { get; set; }
        public int SinifDersKonuId { get; set; }
        public SinifDersKonuDto SinifDersKonu { get; set; }
        public DateTime CalismaTarihi { get; set; }
        public int CalismaSuresi { get; set; } 
    }
}