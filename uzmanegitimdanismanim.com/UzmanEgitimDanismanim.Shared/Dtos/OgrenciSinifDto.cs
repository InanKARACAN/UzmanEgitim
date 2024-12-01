namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class OgrenciSinifDto : BaseDto, IDto
    {
        public int OgrenciId { get; set; }
        public int SinifId { get; set; }
        public string SinifAdi { get; set; }
    }
}
