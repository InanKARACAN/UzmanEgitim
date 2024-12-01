namespace UzmanEgitimDanismanim.Core.Entities
{
    public class Kurum : BaseEntity
    {
        public int Id { get; set; }
        public string KurumAdi { get; set; }
        public string KurumEposta { get; set; }
        public string KurumTel { get; set; }
        public string KurumAdres { get; set; }
    }
}