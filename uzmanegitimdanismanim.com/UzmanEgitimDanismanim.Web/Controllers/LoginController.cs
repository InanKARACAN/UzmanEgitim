using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Shared.Dtos.CustomDtos;

namespace UzmanEgitimDanismanim.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IKullaniciService _kullaniciService;
        private readonly ISinavService _sinavService;
        private readonly IOgrenciSinifService _ogrenciSinifService;


        public LoginController(IHttpContextAccessor httpContextAccessor, IKullaniciService kullaniciService, 
            ISinavService sinavService, IOgrenciSinifService ogrenciSinifService)
        {
            _httpContextAccessor = httpContextAccessor;
            _kullaniciService = kullaniciService;
            _sinavService = sinavService;
            _ogrenciSinifService = ogrenciSinifService;
        }

        private ISession Session => _httpContextAccessor.HttpContext?.Session;

        public IActionResult Index(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (User.Identity != null && User != null && User.Identity.IsAuthenticated)
            {
                if (Url.IsLocalUrl(ViewBag.ReturnUrl))
                    return Redirect(ViewBag.ReturnUrl);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(LoginDto loginDto)
        {
            // ViewBag.ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                var kisi = await _kullaniciService.GirisYap(loginDto);

                if (kisi.Data != null)
                {
                    var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Sid, kisi.Data.Id.ToString()));
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, kisi.Data.RolAdi));
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, kisi.Data.Ad + ' ' + kisi.Data.Soyad));
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Surname, kisi.Data.EnvanterHollandYapildiMi.ToString()));
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Dsa, kisi.Data.KendiniDegerlendirmeEnvanteriYapildiMi.ToString()));
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.DateOfBirth, kisi.Data.UyelikBitisTarihi.ToShortDateString()));
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Actor, kisi.Data.KurumId.ToString()));

                    if(kisi.Data.KullaniciRolId==7) // Kurum Öğrenci
                    {
                        var ogrenciSiniflar = await _ogrenciSinifService.OgrenciSiniflariGetir(kisi.Data.Id);
                        if (ogrenciSiniflar != null)
                        {
                            kisi.Data.SinifId = ogrenciSiniflar.LastOrDefault().SinifId;
                        }
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.SerialNumber, kisi.Data.SinifId.ToString()));

                        //if (kisi.Data.SinifId == 5 || kisi.Data.SinifId == 9)
                        //{
                        int sinavId = 3;
                        string sinavAdi = "LGS";
                        if (kisi.Data.SinifId == 9)
                        {
                            sinavId = 4;
                            sinavAdi = "TYT - AYT";
                        }
                        var sinav = await _sinavService.GetByIdAsync(sinavId);
                        var kalanGun = (sinav.SinavTarihi - DateTime.Now).Days;
                        var gecenOran = 100 - ((kalanGun * 100) / 365);
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Country, sinavAdi));
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.PostalCode, kalanGun.ToString()));
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Dns, gecenOran.ToString()));
                        //}

                        if (!kisi.Data.KendiniDegerlendirmeEnvanteriYapildiMi)
                        {
                            var kullanici = await _kullaniciService.GetByIdAsync(kisi.Data.Id);
                            if (kullanici.OgrenciKendiniDegerlendirmeler != null)
                            {
                                kullanici.KendiniDegerlendirmeEnvanteriYapildiMi = true;
                                var sonuccc = _kullaniciService.Update(kullanici);
                            }
                        }

                    }

                    var authenticationProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(5),
                        IsPersistent = true, // Kullanıcıyı hatırlama (kalıcı oturum) etkinleştirilmişse
                        AllowRefresh = true, // Sayfa yenilendiğinde oturumu yenilemeye izin ver
                    };

                    var userPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(userPrincipal, authenticationProperties);
                    //await HttpContext.SignInAsync(userPrincipal);
                    
                    if (Url.IsLocalUrl(ViewBag.ReturnUrl))
                        return Redirect(ViewBag.ReturnUrl);

                    return Redirect("/DanismanPanel/Anasayfa");

                    //if (kisi.Data.RolAdi == "Admin")
                    //    return Redirect("/Yonetim/Anasayfa");
                    //else
                    //{
                    //    //if (kisi.Data.KullaniciRolId == 7)
                    //    //{
                    //    //    if (!kisi.Data.KendiniDegerlendirmeEnvanteriYapildiMi) return Redirect("/DanismanPanel/Anasayfa/EnvanterKendiniDegerlendirme");
                    //    //    if (!kisi.Data.EnvanterHollandYapildiMi) return Redirect("/DanismanPanel/Anasayfa/EnvanterHolland");
                    //    //}
                    //    return Redirect("/DanismanPanel/Anasayfa");
                    //}
                }
                TempData["Messaj"] = "Girmiş olduğunuz bilgiler doğru görünmüyor.";
            }
            TempData["Messaj"] = "Girmiş olduğunuz bilgiler doğru görünmüyor.";
            return View(viewName: "Index");
        }

        public async Task<IActionResult> CikisYap()
        {
            var prop = new AuthenticationProperties()
            {
                RedirectUri = "/"
            };
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, prop);
            return RedirectToAction("Index");

        }
    }
}
