namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class SinifDersKonuDto : BaseDto, IDto
    {
        public int SinifDersId { get; set; }
        public string SinifDersKonuAdi { get; set; }
        public SinifDersDto SinifDers { get; set; }
    }
}
