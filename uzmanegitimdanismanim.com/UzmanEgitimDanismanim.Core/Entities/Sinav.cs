namespace UzmanEgitimDanismanim.Core.Entities
{
    public class Sinav : BaseEntity
    {
        public int Id { get; set; }
        public string SinavAdi { get; set; }
        public DateTime SinavTarihi{ get; set; }
    }
}