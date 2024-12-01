using Microsoft.AspNetCore.Http;
using UzmanEgitimDanismanim.Shared.Enums;

namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class OgrenciDokumanDto : BaseDto, IDto
    {
        public int OgrenciId { get; set; }
        public OgrenciDokumanKategoriEnum DokumanKategori { get; set; }
        public string Dokuman { get; set; }
        public string DokumanAdi { get; set; }
        public IFormFile Dosya { get; set; }
    }
}