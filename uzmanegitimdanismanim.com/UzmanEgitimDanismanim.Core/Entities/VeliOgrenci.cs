namespace UzmanEgitimDanismanim.Core.Entities
{
    public class VeliOgrenci : BaseEntity
    {
        public int Id { get; set; }
        public int VeliId { get; set; }
        public Kullanici Veli { get; set; }
        public int OgrenciId { get; set; }
        public Kullanici Ogrenci { get; set; }
    }
}
