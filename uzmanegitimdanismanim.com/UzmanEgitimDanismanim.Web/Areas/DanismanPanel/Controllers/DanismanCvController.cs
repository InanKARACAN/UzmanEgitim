using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Web.Areas.DanismanPanel.Controllers
{
    [Authorize]
    [Area("DanismanPanel")]
    public class DanismanCvController : Controller
    {
        IMapper _mapper;
        IOgrenciDokumanService _ogrenciDokumanService;
        IDanismanOgrenciService _danismanOgrenciService;

        static int _ogrenciId = 0;
        
        public DanismanCvController(IMapper mapper, IOgrenciDokumanService ogrenciDokumanService, IDanismanOgrenciService danismanOgrenciService)
        {
            _mapper = mapper;
            _ogrenciDokumanService = ogrenciDokumanService;
            _danismanOgrenciService = danismanOgrenciService;
        }

        public async Task<IActionResult> Index()
        {
            _ogrenciId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            var _danismanOgrenci = await _danismanOgrenciService.OgrenciDanismaniGetir(_ogrenciId);
            var sonuc = _ogrenciDokumanService.OgrenciDokumanGetir(_danismanOgrenci.DanismanId);
            if (sonuc.Count == 0)
            {
                TempData["Durum"] = "False";
                TempData["Mesaj"] = $"Danışman CV'si bulunamadı..!!";
                return View(null);
            }
            else
                return View(sonuc.Where(w=> w.DokumanKategori == Shared.Enums.OgrenciDokumanKategoriEnum.Cv).FirstOrDefault());
        }

    }
}
