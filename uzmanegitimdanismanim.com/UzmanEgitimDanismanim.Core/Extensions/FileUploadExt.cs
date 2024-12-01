using UzmanEgitimDanismanim.Shared.Dtos.CustomDtos;
using UzmanEgitimDanismanim.Shared.Enums;
using UzmanEgitimDanismanim.Shared.Responses;

namespace UzmanEgitimDanismanim.Core.Extensions
{
    public static class FileUploadExt
    {
        public static GResponse<FileUploadResponseDto> DokumanUpload(FileUploadDto fileUploadDto)
        {
            var sonuc = new GResponse<FileUploadResponseDto>("Dosya yüklenemedi..!!");

            var resimContentTypes = new[] { "image/jpg", "image/jpeg", "image/png" };
            var dokumanContentTypes = new[] { "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
            var videoContentTypes = new[] { "video/mp4" };
            var dosyaBoyutu = 1048576 * fileUploadDto.Mb; // MB sınırı

            var dokumanBoyutu = fileUploadDto.Dokuman.Length;
            var dokumanContentType = fileUploadDto.Dokuman.ContentType;

            if (dokumanBoyutu > dosyaBoyutu)
            {
                sonuc.Message = "Dokuman boyutu " + fileUploadDto.Mb + "MB dan büyük olmamalı..!!";
                return sonuc;
            }

            switch (fileUploadDto.Dokuman_Tip)
            {
                case FileTipiEnum.Resim:
                    if (!resimContentTypes.Contains(dokumanContentType))
                    {
                        sonuc.Message = "Resim JPG, JPEG veya PNG formatında olmalı..!!";
                        return sonuc;
                    }
                    break;
                case FileTipiEnum.Dokuman:
                    if (!dokumanContentTypes.Contains(dokumanContentType))
                    {
                        sonuc.Message = "Döküman DOC, DOCX veya PDF formatında olmalı..!!";
                        return sonuc;
                    }
                    break;
                case FileTipiEnum.Video:
                    if (!videoContentTypes.Contains(dokumanContentType))
                    {
                        sonuc.Message = "Döküman MP4 formatında olmalı..!!";
                        return sonuc;
                    }
                    break;
            }

            var uploadPath = fileUploadDto.Upload_Yolu;

            if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

            var fileName = fileUploadDto.Dokuman_Adi;
            var filePath = Path.Combine(uploadPath, fileName);

            using (var strem = File.Create(filePath))
            {
                fileUploadDto.Dokuman.CopyTo(strem);
                sonuc.Data = new FileUploadResponseDto { Sonuc = true, Dokuman = fileName };
            }
            return sonuc;
        }
    }
}
