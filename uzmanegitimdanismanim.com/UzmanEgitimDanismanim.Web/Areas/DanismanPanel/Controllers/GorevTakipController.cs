using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.RegularExpressions;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.Extensions;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Service.Services;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Dtos.CustomDtos;

namespace UzmanEgitimDanismanim.Web.Areas.DanismanPanel.Controllers
{
    [Authorize]
    [Area("DanismanPanel")]
    public class GorevTakipController : Controller
    {
        IMapper _mapper;
        IOgrenciGorevTakipService _ogrenciGorevTakipService;

        static int _ogrenciId = 0;

        public GorevTakipController(IMapper mapper, IOgrenciGorevTakipService ogrenciGorevTakipService)
        {
            _mapper = mapper;
            _ogrenciGorevTakipService = ogrenciGorevTakipService;
        }

        public async Task<IActionResult> Index()
        {
            _ogrenciId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            var sonuc = await _ogrenciGorevTakipService.OgrenciGorevTakipGetir(_ogrenciId);

            if (sonuc.Count ==0)
            {
                TempData["Durum"] = "False";
                TempData["Mesaj"] = $"Size atanmış görev bulunamadı..!!";
            }

            var jsonSonuc = new List<CalenderDto>();

            foreach (var item in sonuc)
            {
                jsonSonuc.Add(new CalenderDto()
                {
                    groupId = item.Silinebilir,
                    overlap = item.Durum.ToString(),
                    id = item.Id.Encrypt(),
                    title = item.Baslik,
                    start = item.GorevBaslangic,
                    end = item.GorevBitis,
                    backgroundColor = "#f39c12", //yellow
                    borderColor = "#f39c12" //yellow
                });
            }

            //var _jsonSonuc = Newtonsoft.Json.JsonConvert.SerializeObject(jsonSonuc);
            //TempData["CalenderDtoList"] = _jsonSonuc;
            return View(jsonSonuc);
        }

        [HttpPost]
        public async Task<IActionResult> OgrenciGorevTakipEkle(OgrenciGorevTakipDto ogrenciGorevTakipDto)
        {
            if (ModelState.IsValid)
            {
               // return RedirectToAction("");
                try
                {
                    ogrenciGorevTakipDto.IslemYapanKullanici = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
                    ogrenciGorevTakipDto.IslemTarihi = DateTime.Now;
                    ogrenciGorevTakipDto.Aktif = true;

                    if (ogrenciGorevTakipDto.OgrenciId == ogrenciGorevTakipDto.IslemYapanKullanici)
                        ogrenciGorevTakipDto.Silinebilir = true;

                    //ogrenciGorevTakipDto.GorevBaslangic = Convert.ToDateTime(ogrenciGorevTakipDto.GorevBaslangic.ToString("dd.MM.yyyy") + ogrenciGorevTakipDto.BaslangicSaat);

                    //var tarih = ogrenciGorevTakipDto.GorevBaslangic;


                    //DateTime.ParseExact(ogrenciGorevTakipDto.GorevBaslangic.ToString("dd.MM.yyyy") + " " +  ogrenciGorevTakipDto.BaslangicSaat, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

                    ogrenciGorevTakipDto.GorevBaslangic = Convert.ToDateTime(ogrenciGorevTakipDto.GorevBaslangic.ToString("dd.MM.yyyy") + " " + ogrenciGorevTakipDto.BaslangicSaat);
                    ogrenciGorevTakipDto.GorevBitis = Convert.ToDateTime(ogrenciGorevTakipDto.GorevBaslangic.ToString("dd.MM.yyyy") + " " + ogrenciGorevTakipDto.BitisSaat);

                    //ogrenciGorevTakipDto.GorevBitis = DateTime.ParseExact(ogrenciGorevTakipDto.GorevBaslangic.ToString("dd.MM.yyyy") + " " +
                    //    ogrenciGorevTakipDto.BitisSaat, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

                    //ogrenciGorevTakipDto.GorevBaslangic = new DateTime(tarih.Year, tarih.Month, tarih.Day, src.Hour, src.Minute, 0);

                    var sonuc = await _ogrenciGorevTakipService.AddAsync(_mapper.Map<OgrenciGorevTakip>(ogrenciGorevTakipDto));
                    TempData["Mesaj"] = "Görev eklendi..!!";
                }
                catch (Exception ex)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = ex.ToString();
                }
            }
            return RedirectToAction("");
        }


        /// Durum =>> Sil = 0, Tamamlandi = 1, Tamamlanmadi = 2

        public async Task<IActionResult> OgrenciGorevTakipGuncelle(string id, byte durum)
        {
            var _id = EncryptDecrypExt.Decrypt(id);

            var gorevTakip = await _ogrenciGorevTakipService.GetByIdAsync(Convert.ToInt32(_id));

            if (gorevTakip == null)
            {
                TempData["Durum"] = "False";
                TempData["Mesaj"] = "Kayıt bulunamadı..!!";
            }
            else
            {
                gorevTakip.Durum = Shared.Enums.GorevTakipDurumEnum.Tamamlandi;
                var sonuc = _ogrenciGorevTakipService.Update(gorevTakip);
                if (sonuc == null)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = "Kayıt güncellenirken bir hata oluştu. Ltfen sonra tekrar deneyiniz..!!";
                }
                else
                {
                    TempData["Mesaj"] = "Kayıt güncellendi..!!";
                }

            }
            return Redirect("/DanismanPanel/GorevTakip");

        }

        public async Task<IActionResult> OgrenciGorevTakipTamamladi(string id)
        {
            var _id = EncryptDecrypExt.Decrypt(id);

            var gorevTakip = await _ogrenciGorevTakipService.GetByIdAsync(Convert.ToInt32(_id));

            if (gorevTakip == null)
            {
                TempData["Durum"] = "False";
                TempData["Mesaj"] = "Kayıt bulunamadı..!!";
            }
            else
            {
                gorevTakip.Durum = Shared.Enums.GorevTakipDurumEnum.Tamamlandi;
                var sonuc = _ogrenciGorevTakipService.Update(gorevTakip);
                if (sonuc == null)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = "Kayıt güncellenirken bir hata oluştu. Ltfen sonra tekrar deneyiniz..!!";
                }
                else
                {
                    TempData["Mesaj"] = "Kayıt güncellendi..!!";
                }

            }
            return Redirect("/DanismanPanel/GorevTakip");

        }

        public async Task<IActionResult> OgrenciGorevTakipTamamlamadi(string id)
        {
            var _id = EncryptDecrypExt.Decrypt(id);

            var gorevTakip = await _ogrenciGorevTakipService.GetByIdAsync(Convert.ToInt32(_id));

            if (gorevTakip == null)
            {
                TempData["Durum"] = "False";
                TempData["Mesaj"] = "Kayıt bulunamadı..!!";
            }
            else
            {
                gorevTakip.Durum = Shared.Enums.GorevTakipDurumEnum.Tamamlanmadi;
                var sonuc = _ogrenciGorevTakipService.Update(gorevTakip);
                if (sonuc == null)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = "Kayıt güncellenirken bir hata oluştu. Ltfen sonra tekrar deneyiniz..!!";
                }
                else
                {
                    TempData["Mesaj"] = "Kayıt güncellendi..!!";
                }

            }
            return Redirect("/DanismanPanel/GorevTakip");

        }

        public async Task<IActionResult> OgrenciGorevTakipSil(string id)
        {
            var _id = EncryptDecrypExt.Decrypt(id);

            var gorevTakip = await _ogrenciGorevTakipService.GetByIdAsync(Convert.ToInt32(_id));

            if (gorevTakip == null)
            {
                TempData["Durum"] = "False";
                TempData["Mesaj"] = "Kayıt bulunamadı..!!";
            }
            else
            {
                gorevTakip.Silindi = true;
                var sonuc = _ogrenciGorevTakipService.Update(gorevTakip);
                if (sonuc == null)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = "Kayıt silinirken bir hata oluştu. Ltfen sonra tekrar deneyiniz..!!";
                }
                else
                {
                    TempData["Mesaj"] = "Kayıt silindi..!!";
                }

            }
            return Redirect("/DanismanPanel/GorevTakip");

        }


    }
}
