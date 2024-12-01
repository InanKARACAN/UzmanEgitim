namespace UzmanEgitimDanismanim.Core.Entities
{
    public class DanismanOgrenci : BaseEntity
    {
        public int Id { get; set; }
        public int DanismanId { get; set; }
        public Kullanici Danisman { get; set; }
        public int OgrenciId { get; set; }
        public Kullanici Ogrenci { get; set; }
    }
}
