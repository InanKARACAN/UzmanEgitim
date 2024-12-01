namespace UzmanEgitimDanismanim.Core.Entities
{
    public class SinavDersKonu : BaseEntity
    {
        public int Id { get; set; }
        public int SinavDersId { get; set; }
        public SinavDers SinavDers { get; set; }
        public string SinavDersKonuAdi { get; set; }
    }
}