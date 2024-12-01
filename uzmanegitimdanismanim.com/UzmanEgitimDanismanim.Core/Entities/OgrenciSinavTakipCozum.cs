using UzmanEgitimDanismanim.Shared.Enums;

namespace UzmanEgitimDanismanim.Core.Entities
{
    public class OgrenciSinavTakipCozum : BaseEntity
    {
        public int Id { get; set; }
        public int OgrenciSinavTakipId { get; set; }
        public OgrenciSinavTakip OgrenciSinavTakip { get; set; }
        public int SinavDersId { get; set; }
        public SinavDers SinavDers { get; set; }
        public int Dogru { get; set; }
        public int Yanlis { get; set; }
        public int Bos { get; set; }
    }
}