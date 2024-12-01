namespace UzmanEgitimDanismanim.Core.Entities
{
    public class OgrenciSinif : BaseEntity
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public Kullanici Ogrenci { get; set; }
        public int SinifId { get; set; }
        public Sinif Sinif { get; set; }
    }
}