using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UzmanEgitimDanismanim.Core.IServices;

namespace UzmanEgitimDanismanim.Web.Areas.DanismanPanel.Controllers
{
    [Authorize]
    [Area("DanismanPanel")]
    public class KaynakOnerisiController : Controller
    {
        IMapper _mapper;
        IOgrenciDokumanService _ogrenciDokumanService;

        static int _ogrenciId = 0;
        
        public KaynakOnerisiController(IMapper mapper, IOgrenciDokumanService ogrenciDokumanService)
        {
            _mapper = mapper;
            _ogrenciDokumanService = ogrenciDokumanService;
        }

        public IActionResult Index()
        {
            _ogrenciId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);

            var sonuc = _ogrenciDokumanService.OgrenciDokumanGetir(_ogrenciId);

            var kaynakOnerileri = sonuc.Where(w => w.DokumanKategori == Shared.Enums.OgrenciDokumanKategoriEnum.KaynakOnerisi).ToList();
            if (kaynakOnerileri.Count == 0)
            {
                TempData["Durum"] = "False";
                TempData["Mesaj"] = $"Kaynak önerisi bulunamadı..!!";
            }
            return View(kaynakOnerileri);
        }

    }
}
