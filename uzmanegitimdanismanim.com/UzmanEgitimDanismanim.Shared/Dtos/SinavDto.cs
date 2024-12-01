namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class SinavDto : BaseDto, IDto
    {
        public string SinavAdi { get; set; }
        public DateTime SinavTarihi { get; set; }
    }
}