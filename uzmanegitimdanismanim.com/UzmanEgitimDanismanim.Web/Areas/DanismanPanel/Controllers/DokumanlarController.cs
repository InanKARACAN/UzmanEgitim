using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UzmanEgitimDanismanim.Core.IServices;

namespace UzmanEgitimDanismanim.Web.Areas.DanismanPanel.Controllers
{
    [Authorize]
    [Area("DanismanPanel")]
    public class DokumanlarController : Controller
    {
        IMapper _mapper;
        IOgrenciDokumanService _ogrenciDokumanService;

        static int _ogrenciId = 0;
        
        public DokumanlarController(IMapper mapper, IOgrenciDokumanService ogrenciDokumanService)
        {
            _mapper = mapper;
            _ogrenciDokumanService = ogrenciDokumanService;
        }

        public IActionResult Index()
        {
            _ogrenciId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);

            var sonuc = _ogrenciDokumanService.OgrenciDokumanGetir(_ogrenciId);

            var dokumanlar = sonuc.Where(w => w.DokumanKategori == Shared.Enums.OgrenciDokumanKategoriEnum.Dokumanlar).ToList();
            if (dokumanlar.Count == 0)
            {
                TempData["Durum"] = "False";
                TempData["Mesaj"] = $"Eklenmiş döküman bulunamadı..!!";
            }
            return View(dokumanlar);
        }

    }
}
