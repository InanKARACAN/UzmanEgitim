using UzmanEgitimDanismanim.Shared.Enums;

namespace UzmanEgitimDanismanim.Core.Entities
{
    public class OgrenciDokuman : BaseEntity
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public Kullanici Ogrenci { get; set; }
        public OgrenciDokumanKategoriEnum DokumanKategori { get; set; }
        public string Dokuman { get; set; }
        public string DokumanAdi { get; set; }
    }
}