using Microsoft.AspNetCore.Http;
using UzmanEgitimDanismanim.Shared.Enums;

namespace UzmanEgitimDanismanim.Shared.Dtos.CustomDtos
{
    public class FileUploadDto
    {
        public IFormFile Dokuman { get; set; }
        public FileTipiEnum Dokuman_Tip { get; set; }
        public string Dokuman_Adi { get; set; }
        public string Upload_Yolu { get; set; }
        public int Mb { get; set; }
    }
}
