using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.Extensions;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Shared.Common;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.ViewModels;

namespace UzmanEgitimDanismanim.Web.Areas.DanismanPanel.Controllers
{
    [Authorize]
    [Area("DanismanPanel")]
    public class SoruTakipController : Controller
    {
        IMapper _mapper;
        IOgrenciSoruTakipService _ogrenciSoruTakipService;
        IOgrenciSinifService _ogrenciSinifService;
        ISinifDersService _sinifDersService;
        ISinifDersKonuService _sinifDersKonuService;

        static int _ogrenciId = 0;
        static int _sinifId = 0;
        private static int _pageSize = 20;

        public SoruTakipController(IMapper mapper,
            IOgrenciSoruTakipService ogrenciSoruTakipService, 
            IOgrenciSinifService ogrenciSinifService,
            ISinifDersService sinifDersService, 
            ISinifDersKonuService sinifDersKonuService)
        {
            _mapper = mapper;
            _ogrenciSoruTakipService = ogrenciSoruTakipService;
            _ogrenciSinifService = ogrenciSinifService;
            _sinifDersService = sinifDersService;
            _sinifDersKonuService = sinifDersKonuService;
        }

        public async Task<IActionResult> Index(SoruTakipViewModel model)
        {
            _ogrenciId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            var siniflar = await _ogrenciSinifService.OgrenciSiniflariGetir(_ogrenciId);
            _sinifId = siniflar.OrderByDescending(o => o.SinifId).Select(s => s.SinifId).FirstOrDefault();
            await SinifDersDoldur(_sinifId);

            if (ModelState.IsValid)
            {
                model.araViewModel.OgrenciId = _ogrenciId;
                model.araViewModel.SinifId = _sinifId;

                var page = model.araViewModel.request.Page;
                if (page == 0) page = 1;

                model.araViewModel.request = new PagerRequest();
                model.araViewModel.request.Page = page;
                model.araViewModel.request.PageSize = _pageSize;

                var sonuc = await _ogrenciSoruTakipService.OgrenciSoruTakipGetir(model.araViewModel);
                if (sonuc.Items.Count == 0)
                {
                    model.PageInfo.TotalItems = 1;
                    model.PageInfo.ItemsPerPage = 1;
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = $"Aradığınız kriterlere uygun kayıt bulunamadı..!!";
                    return View(model);
                }
                else
                {
                    foreach (var _sonuc in sonuc.Items)
                    {
                        _sonuc.EncryptedId = _sonuc.Id.Encrypt();
                    }
                }

                model.Model = sonuc;
                model.PageInfo.CurrentPage = page;
                model.PageInfo.TotalItems = model.Model.TotalItems;
                model.PageInfo.ItemsPerPage = _pageSize;
                return View(model);
            }
            return View(model);
        }

        async Task SinifDersDoldur(int sinifId)
        {
            var sinifDersleri = await _sinifDersService.SinifDersleriGetir(sinifId);

            IEnumerable<SelectListItem> itemsSinifDersleri = sinifDersleri.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.SinifDersAdi
            });
            await SinifDersKonuDoldur(Convert.ToInt32(itemsSinifDersleri.Select(s => s.Value).FirstOrDefault()));
            ViewBag.SinifDersListesi = itemsSinifDersleri;
        }

        async Task SinifDersKonuDoldur(int sinifDersId)
        {
            var sinifDersKonular = await _sinifDersKonuService.SinifDersKonulariGetir(sinifDersId);

            IEnumerable<SelectListItem> itemsSinifDersKonulari = sinifDersKonular.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.SinifDersKonuAdi
            });
            ViewBag.SinifDersKonuListesi = itemsSinifDersKonulari;
        }

        public async Task<List<SinifDersKonuDto>> SinifDersKonuGetir(int sinifDersId)
        {
            var sinifDersKonular = await _sinifDersKonuService.SinifDersKonulariGetir(sinifDersId);
            return sinifDersKonular;
        }

        [HttpPost]
        public async Task<IActionResult> OgrenciSoruTakipEkle(OgrenciSoruTakipDto ogrenciSoruTakipDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ogrenciSoruTakipDto.IslemYapanKullanici = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
                    ogrenciSoruTakipDto.IslemTarihi = DateTime.Now;
                    ogrenciSoruTakipDto.Aktif = true;
                    var sonuc = await _ogrenciSoruTakipService.AddAsync(_mapper.Map<OgrenciSoruTakip>(ogrenciSoruTakipDto));
                    TempData["Mesaj"] = "Çalışma eklendi..!!";
                }
                catch (Exception ex)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = ex.ToString();
                }
            }
            return RedirectToAction("");
        }

        public async Task<IActionResult> OgrenciSoruTakipSil(string id)
        {
            var _id = EncryptDecrypExt.Decrypt(id);

            var konuTakip = await _ogrenciSoruTakipService.GetByIdAsync(Convert.ToInt32(_id));

            if (konuTakip == null)
            {
                TempData["Durum"] = "False";
                TempData["Mesaj"] = "Kayıt bulunamadı..!!";
            }
            else
            {
                konuTakip.Silindi = true;
                var sonuc = _ogrenciSoruTakipService.Update(konuTakip);
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
            return Redirect("/DanismanPanel/SoruTakip");

        }

        public async Task<string> OgrenciSoruGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi)
        {
            var sonuc = await _ogrenciSoruTakipService.OgrenciSoruGrafikGetir(ogrenciId, sinifId, baslangicTarihi, bitisTarihi);

            if (sonuc.Count == 0)
                return "";

            var result = sonuc.GroupBy(dto => dto.SinifDersKonu.SinifDers.SinifDersAdi)
                          .Select(group => new
                          {
                              Name = group.Key,
                              Count = group.Sum(dto => dto.Adet)
                          })
                          .ToList();

            var str = "{\"labels\": [";


            var last = result.Last();
            foreach (var item in result)
            {
                if (item == last)
                {
                    str += "\"" + item.Name + "\"";
                }
                else
                {
                    str += "\"" + item.Name + "\",";
                }
            }
            str += "]," +
     "\"data\": [";

            foreach (var item in result)
            {
                if (item == last)
                {
                    str += item.Count;
                }
                else
                {
                    str += item.Count + ",";
                }
            }


            str += "]"
                + "}";

            return str;
        }

        public async Task<string> OgrenciSoruKonuGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi, string dersAdi)
        {
            var sonuc = await _ogrenciSoruTakipService.OgrenciSoruKonuGrafikGetir(ogrenciId, sinifId, baslangicTarihi, bitisTarihi, dersAdi);

            if (sonuc.Count == 0)
                return "";

            var result = sonuc.GroupBy(dto => dto.SinifDersKonu.SinifDersKonuAdi)
                          .Select(group => new
                          {
                              Name = group.Key,
                              Count = group.Sum(dto => dto.Adet)
                          })
                          .ToList();

            var str = "{\"labels\": [";


            var last = result.Last();
            foreach (var item in result)
            {
                if (item == last)
                {
                    str += "\"" + item.Name + "\"";
                }
                else
                {
                    str += "\"" + item.Name + "\",";
                }
            }
            str += "]," +
     "\"data\": [";

            foreach (var item in result)
            {
                if (item == last)
                {
                    str += item.Count;
                }
                else
                {
                    str += item.Count + ",";
                }
            }


            str += "]"
                + "}";

            return str;
        }
    }
}
