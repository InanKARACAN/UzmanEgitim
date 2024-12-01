namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class OgrenciSinavTakipCozumDto : BaseDto, IDto
    {
        public int OgrenciSinavTakipId { get; set; }
        public int SinavDersId { get; set; }
        public int Dogru { get; set; }
        public int Yanlis { get; set; }
        public int Bos { get; set; }
        public decimal Net { get; set; }
        public decimal Net3 { get; set; }
        public SinavDersDto SinavDers { get; set; }
    }
}