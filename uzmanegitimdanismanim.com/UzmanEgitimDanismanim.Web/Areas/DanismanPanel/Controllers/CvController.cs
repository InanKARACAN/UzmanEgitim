using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.Extensions;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Dtos.CustomDtos;
using UzmanEgitimDanismanim.Shared.Enums;

namespace UzmanEgitimDanismanim.Web.Areas.DanismanPanel.Controllers
{
    [Authorize]
    [Area("DanismanPanel")]
    public class CvController : Controller
    {
        IMapper _mapper;
        IKullaniciService _kullaniciService;
        IKullaniciRolService _kullaniciRolService;
        ISinifService _sinifService;
        IOgrenciSinifService _ogrenciSinifService;
        IDanismanOgrenciService _danismanOgrenciService;
        IOgrenciGorevTakipService _ogrenciGorevTakipService;
        IOgrenciSinavTakipService _ogrenciSinavTakipService;
        IOgrenciDokumanService _ogrenciDokumanService;

  
        public CvController(IMapper mapper,
            IKullaniciService kullaniciService,
            IKullaniciRolService kullaniciRolService,
            ISinifService sinifService,
            IOgrenciSinifService ogrenciSinifService,
            IDanismanOgrenciService danismanOgrenciService,
            IOgrenciGorevTakipService ogrenciGorevTakipService,
            IOgrenciSinavTakipService ogrenciSinavTakipService,
            IOgrenciDokumanService ogrenciDokumanService)
        {
            _mapper = mapper;
            _kullaniciService = kullaniciService;
            _kullaniciRolService = kullaniciRolService;
            _sinifService = sinifService;
            _ogrenciSinifService = ogrenciSinifService;
            _danismanOgrenciService = danismanOgrenciService;
            _ogrenciGorevTakipService = ogrenciGorevTakipService;
            _ogrenciSinavTakipService = ogrenciSinavTakipService;
            _ogrenciSinavTakipService = ogrenciSinavTakipService;
            _ogrenciDokumanService = ogrenciDokumanService;
        }

        public async Task<IActionResult> CvEkle()
        {
            var danismanId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            var sonuc = _ogrenciDokumanService.OgrenciDokumanGetir(danismanId);
            return View(sonuc.Where(w => w.DokumanKategori == Shared.Enums.OgrenciDokumanKategoriEnum.Cv).FirstOrDefault());
        }


        [HttpPost]
        public async Task<IActionResult> CvEkle(OgrenciDokumanDto ogrenciDokumanDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ogrenciDokumanDto.Dosya.Length > 0)
                    {
                        var dosyaUzunAdi = ogrenciDokumanDto.Dosya.FileName.Split(".");

                        FileUploadDto fileUploadDto = new FileUploadDto()
                        {
                            Dokuman = ogrenciDokumanDto.Dosya,
                            Dokuman_Adi = Guid.NewGuid().ToString() + "." + dosyaUzunAdi[1],
                            Dokuman_Tip = FileTipiEnum.Dokuman,
                            Upload_Yolu = "wwwroot/Panel/Files/Cv",
                            Mb = 3
                        };

                        var dokumanUpload = FileUploadExt.DokumanUpload(fileUploadDto);

                        if (dokumanUpload.Data == null)
                        {
                            TempData["Durum"] = "False";
                            TempData["Mesaj"] = dokumanUpload.Message;
                            return View(ogrenciDokumanDto);
                        }
                        ogrenciDokumanDto.Dokuman = dokumanUpload.Data.Dokuman;
                        
                    }

                    var danismanId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);

                    ogrenciDokumanDto.DokumanAdi = ogrenciDokumanDto.Dosya.FileName;
                    ogrenciDokumanDto.IslemYapanKullanici = danismanId;
                    ogrenciDokumanDto.IslemTarihi = DateTime.Now;
                    ogrenciDokumanDto.Aktif = true;
                    ogrenciDokumanDto.DokumanKategori = Shared.Enums.OgrenciDokumanKategoriEnum.Cv;

                    ogrenciDokumanDto.Dosya = null;

                    var sonuc = await _ogrenciDokumanService.AddAsync(_mapper.Map<OgrenciDokuman>(ogrenciDokumanDto));
                    if (sonuc != null)
                    {
                        TempData["Mesaj"] = "Cv başarılı bir şekilde eklendi..!!";
                        return new RedirectResult(Url.Action("CvEkle"));
                    }
                }
                catch (Exception ex)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = ex.ToString();
                }
            }
            return new RedirectResult(Url.Action("CvEkle"));
        }


    }
}
