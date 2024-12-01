namespace UzmanEgitimDanismanim.Core.Entities
{
    public class SinifDers : BaseEntity
    {
        public int Id { get; set; }
        public int SinifId { get; set; }
        public Sinif Sinif { get; set; }
        public string SinifDersAdi { get; set; }
    }
}