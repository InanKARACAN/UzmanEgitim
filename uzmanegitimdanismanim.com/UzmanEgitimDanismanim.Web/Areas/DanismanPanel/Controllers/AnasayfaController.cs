using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Web.Areas.DanismanPanel.Controllers
{
    [Authorize]
    [Area("DanismanPanel")]
    public class AnasayfaController : Controller
    {
        IMapper _mapper;
        IOgrenciEnvanteriHollandService _ogrenciEnvanteriHollandService;
        IOgrenciKendiniDegerlendirmeService _ogrenciKendiniDegerlendirmeService;
        IKullaniciService _kullaniciService;
        IVeliOgrenciService _veliOgrenciService;
        IOgrenciSinifService _ogrenciSinifService;

        static string role;
        static int _ogrenciId = 0;

        public AnasayfaController(IMapper mapper, 
            IOgrenciEnvanteriHollandService ogrenciEnvanteriHollandService, IOgrenciKendiniDegerlendirmeService ogrenciKendiniDegerlendirmeService, 
            IKullaniciService kullaniciService, IVeliOgrenciService veliOgrenciService, IOgrenciSinifService ogrenciSinifService)
        {
            _mapper = mapper;
            _ogrenciEnvanteriHollandService = ogrenciEnvanteriHollandService;
            _ogrenciKendiniDegerlendirmeService = ogrenciKendiniDegerlendirmeService;
            _kullaniciService = kullaniciService;
            _veliOgrenciService = veliOgrenciService;
            _ogrenciSinifService = ogrenciSinifService;
        }
        
        public async Task<IActionResult> Index()
        {
            role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            switch (role)
            {
                case "Kurum Öğrenci":
                    _ogrenciId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
                    await OgrenciDoldur(_ogrenciId);
                    
                    break;
                case "Kurum Veli":
                    await OgrenciDoldur();
                    break;
            }

            return View();
        }

        async Task OgrenciDoldur(int ogrenciId = 0)
        {
            List<SelectListItem> itemsOgrenciler = new List<SelectListItem>();
            if (ogrenciId == 0)
            {
                var _veliId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
                var ogrenciler = await _veliOgrenciService.VeliOgrencileriGetir(_veliId);
                foreach (var item in ogrenciler)
                {
                    itemsOgrenciler.Add(new SelectListItem { Text = item.Ogrenci.Ad + " " + item.Ogrenci.Soyad, Value = item.Ogrenci.Id.ToString() });
                }
                await OgrenciSinifDoldur(Convert.ToInt32(itemsOgrenciler.FirstOrDefault().Value));
            }
            else
            {
                var ogrenci = await _kullaniciService.GetByIdAsync(ogrenciId);
                itemsOgrenciler.Add(new SelectListItem { Text = ogrenci.Ad + " " + ogrenci.Soyad, Value = ogrenci.Id.ToString() });
                await OgrenciSinifDoldur(_ogrenciId);
            }
            ViewBag.OgrenciListesi = itemsOgrenciler;
        }

        async Task OgrenciSinifDoldur(int ogrenciId)
        {
            var ogrenciSiniflar = await _ogrenciSinifService.OgrenciSiniflariGetir(ogrenciId);

            IEnumerable<SelectListItem> itemsOgrenciSiniflar = ogrenciSiniflar.Select(s => new SelectListItem
            {
                Value = s.SinifId.ToString(),
                Text = s.SinifAdi
            });
            ViewBag.OgrenciSinifListesi = itemsOgrenciSiniflar;
        }

        public async Task<List<OgrenciSinifDto>> OgrenciSinifGetir(int ogrenciId)
        {
            var ogrenciSiniflar = await _ogrenciSinifService.OgrenciSiniflariGetir(ogrenciId);
            return ogrenciSiniflar;
        }

        public IActionResult EnvanterHolland()
        {
            return View(new OgrenciEnvanteriHollandDto());
        }

        [HttpPost]
        public async Task<IActionResult> EnvanterHolland(OgrenciEnvanteriHollandDto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.IslemYapanKullanici = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
                    model.IslemTarihi = DateTime.Now;
                    model.Aktif = true;
                    var sonuc = await _ogrenciEnvanteriHollandService.AddAsync(_mapper.Map<OgrenciEnvanteriHolland>(model));
                    var kullanici = await _kullaniciService.GetByIdAsync(model.IslemYapanKullanici);
                    kullanici.EnvanterHollandYapildiMi = true;
                    var sonuccc = _kullaniciService.Update(kullanici);
                    TempData["Mesaj"] = "Holland envanteri eklendi..!!";
                    Response.Redirect("/Login/CikisYap");
                }
                catch (Exception ex)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = ex.ToString();
                }

                var s = model;
            }
            return View(model);
        }


        public IActionResult EnvanterKendiniDegerlendirme()
        {
            return View(new OgrenciKendiniDegerlendirmeDto());
        }

        [HttpPost]
        public async Task<IActionResult> EnvanterKendiniDegerlendirme(OgrenciKendiniDegerlendirmeDto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.IslemYapanKullanici = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
                    model.IslemTarihi = DateTime.Now;
                    model.Aktif = true;
                    var sonuc = await _ogrenciKendiniDegerlendirmeService.AddAsync(_mapper.Map<OgrenciKendiniDegerlendirme>(model));
                    var kullanici = await _kullaniciService.GetByIdAsync(model.IslemYapanKullanici);
                    kullanici.KendiniDegerlendirmeEnvanteriYapildiMi = true;
                    var sonuccc = _kullaniciService.Update(kullanici);
                    TempData["Messaj"] = "Kendini Değerlendirme envanteri eklendi..!!";
                    Response.Redirect("/Login/CikisYap");
                }
                catch (Exception ex)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = ex.ToString();
                }

                var s = model;
            }
            return View(model);
        }


    }
}
