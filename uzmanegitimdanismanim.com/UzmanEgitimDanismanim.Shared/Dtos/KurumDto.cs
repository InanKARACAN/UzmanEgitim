namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class KurumDto : BaseDto, IDto
    {
        public string KurumAdi { get; set; }
        public string KurumEposta { get; set; }
        public string KurumTel { get; set; }
        public string KurumAdres { get; set; }
    }
}
