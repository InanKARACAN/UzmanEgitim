namespace UzmanEgitimDanismanim.Core.Entities
{
    public class SinavDers : BaseEntity
    {
        public int Id { get; set; }
        public int SinavId { get; set; }
        public Sinav Sinav { get; set; }
        public string SinavDersAdi { get; set; }
        //public ICollection<OgrenciSinavTakipCozum> OgrenciSinavTakipCozumler { get; set; }
    }
}