namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class OgrenciSoruTakipDto : BaseDto, IDto
    {
        public int OgrenciId { get; set; }
        public int SinifDersKonuId { get; set; }
        public SinifDersKonuDto SinifDersKonu { get; set; }
        public DateTime CozumTarihi { get; set; }
        public int Adet { get; set; }
    }
}