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
    public class DenemeTakipController : Controller
    {
        IMapper _mapper;
        ISinavService _sinavService;
        //IOgrenciSinifService _ogrenciSinifService;
        //ISinifDersService _sinifDersService;
        IOgrenciSinavTakipService _ogrenciSinavTakipService;

        static int _ogrenciId = 0;
        private static int _pageSize = 20;

        public DenemeTakipController(IMapper mapper, ISinavService sinavService, 
            IOgrenciSinavTakipService ogrenciSinavTakipService)
        {
            _mapper = mapper;
            _sinavService = sinavService;
            _ogrenciSinavTakipService = ogrenciSinavTakipService;
        }

        public async Task<IActionResult> Index(SinavTakipViewModel model)
        {
            _ogrenciId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            await SinavDoldur();

            if (ModelState.IsValid)
            {
                model.araViewModel.OgrenciId = _ogrenciId;

                var page = model.araViewModel.request.Page;
                if (page == 0) page = 1;

                model.araViewModel.request = new PagerRequest();
                model.araViewModel.request.Page = page;
                model.araViewModel.request.PageSize = _pageSize;

                var sonuc = await _ogrenciSinavTakipService.OgrenciSinavTakipGetir(model.araViewModel);
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

        async Task SinavDoldur()
        {
            var sinavlar = await _sinavService.GetAllAsync();

            var sinifId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.SerialNumber).Value);
            if(sinifId < 6 ) //LGS
            {
                sinavlar = sinavlar.Where(w => w.Id == 3).ToList();
            }
            else // TYT-AYT
            {
                sinavlar = sinavlar.Where(w => w.Id > 3).ToList();
            }

            IEnumerable<SelectListItem> itemsSinavlar = sinavlar.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.SinavAdi
            });
            ViewBag.SinavListesi = itemsSinavlar;
        }

        [HttpPost]
        public async Task<IActionResult> OgrenciDenemeTakipEkle(OgrenciSinavTakipDto ogrenciSinavTakipDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ogrenciSinavTakipDto.IslemYapanKullanici = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
                    ogrenciSinavTakipDto.IslemTarihi = DateTime.Now;
                    ogrenciSinavTakipDto.Aktif = true;
                    var sonuc = await _ogrenciSinavTakipService.AddAsync(_mapper.Map<OgrenciSinavTakip>(ogrenciSinavTakipDto));
                    TempData["Mesaj"] = "Deneme eklendi..!!";
                }
                catch (Exception ex)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = ex.ToString();
                }
            }
            return RedirectToAction("");
        }

        public async Task<IActionResult> OgrenciDenemeTakipSil(string id)
        {
            var _id = EncryptDecrypExt.Decrypt(id);

            var denemeTakip = await _ogrenciSinavTakipService.GetByIdAsync(Convert.ToInt32(_id));

            if (denemeTakip == null)
            {
                TempData["Durum"] = "False";
                TempData["Mesaj"] = "Kayıt bulunamadı..!!";
            }
            else
            {
                denemeTakip.Silindi = true;
                var sonuc = _ogrenciSinavTakipService.Update(denemeTakip);
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
            return Redirect("/DanismanPanel/DenemeTakip");

        }


    }
}
