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
using UzmanEgitimDanismanim.Shared.Dtos.CustomDtos;
using UzmanEgitimDanismanim.Shared.Enums;
using UzmanEgitimDanismanim.Shared.ViewModels;

namespace UzmanEgitimDanismanim.Web.Areas.DanismanPanel.Controllers
{
    [Authorize]
    [Area("DanismanPanel")]
    public class OgrenciController : Controller
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

        private static int _pageSize = 20;
        private static int _ogrenciSinifId;

        //static int _ogrenciId = 0;
        //static int _sinifId = 0;

        public OgrenciController(IMapper mapper,
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

        public async Task<IActionResult> OgrenciEkle()
        {
            await SinifDoldur();
            return View(new KullaniciDto());
        }

        async Task SinifDoldur()
        {
            var siniflar = await _sinifService.GetAllAsync();
            IEnumerable<SelectListItem> itemsSiniflar = siniflar.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.SinifAdi
            });
            ViewBag.SinifListesi = itemsSiniflar;
        }


        [HttpPost]
        public async Task<IActionResult> OgrenciEkle(KullaniciDto kullaniciDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var danismanId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);

                    kullaniciDto.IslemYapanKullanici = danismanId;
                    kullaniciDto.IslemTarihi = DateTime.Now;
                    kullaniciDto.Aktif = true;
                    kullaniciDto.EnvanterHollandYapildiMi = true;
                    kullaniciDto.KendiniDegerlendirmeEnvanteriYapildiMi = true;

                    var sonuc = await _kullaniciService.AddAsync(_mapper.Map<Kullanici>(kullaniciDto));

                    if (sonuc.Id > 0)
                    {
                        OgrenciSinifDto ogrenciSinifDto = new OgrenciSinifDto();
                        ogrenciSinifDto.OgrenciId = sonuc.Id;
                        ogrenciSinifDto.SinifId = kullaniciDto.SinifId;
                        ogrenciSinifDto.IslemYapanKullanici = danismanId;
                        ogrenciSinifDto.IslemTarihi = DateTime.Now;
                        ogrenciSinifDto.Aktif = true;
                        var ogrenciSinifSonuc = await _ogrenciSinifService.AddAsync(_mapper.Map<OgrenciSinif>(ogrenciSinifDto));


                        DanismanOgrenciDto danismanOgrenciDto = new DanismanOgrenciDto();
                        danismanOgrenciDto.DanismanId = danismanId;
                        danismanOgrenciDto.OgrenciId = sonuc.Id;
                        danismanOgrenciDto.IslemYapanKullanici = danismanId;
                        danismanOgrenciDto.IslemTarihi = DateTime.Now;
                        danismanOgrenciDto.Aktif = true;
                        var danismanOgrenciSonuc = await _danismanOgrenciService.AddAsync(_mapper.Map<DanismanOgrenci>(danismanOgrenciDto));
                    }

                    TempData["Mesaj"] = "Öğrenci başarılı bir şekilde eklendi..!!";
                    return new RedirectResult(Url.Action("OgrenciListele"));
                }
                catch (Exception ex)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = ex.ToString();
                }
            }
            return View(kullaniciDto);
        }

        public async Task<IActionResult> OgrenciListele(OgrenciListeleViewModel ogrenciListeleViewModel)
        {
            var _danismanId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            var _kurumId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor).Value);
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            //var siniflar = await _ogrenciSinifService.OgrenciSiniflariGetir(_ogrenciId);
            //_sinifId = siniflar.Select(s => s.SinifId).FirstOrDefault();
            //await SinifDersDoldur(_sinifId);


            if (ModelState.IsValid)
            {
                ogrenciListeleViewModel.araViewModel.DanismanID = _danismanId;
                ogrenciListeleViewModel.araViewModel.KurumID = _kurumId;

                var page = ogrenciListeleViewModel.araViewModel.request.Page;
                if (page == 0) page = 1;

                ogrenciListeleViewModel.araViewModel.request = new PagerRequest();
                ogrenciListeleViewModel.araViewModel.request.Page = page;
                ogrenciListeleViewModel.araViewModel.request.PageSize = _pageSize;

                Shared.Responses.PagedModel<DanismanOgrenciDto> sonuc = new Shared.Responses.PagedModel<DanismanOgrenciDto>();

                switch (role)
                {
                    case "Kurum Yönetici":
                        sonuc = await _danismanOgrenciService.KurumOgrencileriGetir(ogrenciListeleViewModel.araViewModel);
                        break;
                    case "Kurum Danışman":
                        sonuc = await _danismanOgrenciService.DanismanOgrencileriGetir(ogrenciListeleViewModel.araViewModel);
                        break;
                }

                if (sonuc.Items.Count == 0)
                {
                    ogrenciListeleViewModel.PageInfo.TotalItems = 1;
                    ogrenciListeleViewModel.PageInfo.ItemsPerPage = 1;
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = $"Aradığınız kriterlere uygun kayıt bulunamadı..!!";
                    return View(ogrenciListeleViewModel);
                }
                else
                {
                    foreach (var _sonuc in sonuc.Items)
                    {
                        _sonuc.EncryptedId = _sonuc.Ogrenci.Id.Encrypt();
                    }
                }

                ogrenciListeleViewModel.Model = sonuc;
                ogrenciListeleViewModel.PageInfo.CurrentPage = page;
                ogrenciListeleViewModel.PageInfo.TotalItems = ogrenciListeleViewModel.Model.TotalItems;
                ogrenciListeleViewModel.PageInfo.ItemsPerPage = _pageSize;
                return View(ogrenciListeleViewModel);
            }
            return View(ogrenciListeleViewModel);
        }

        public async Task<IActionResult> OgrenciDetay(string id)
        {
            OgrenciDetayViewModel model = new OgrenciDetayViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                await SinifDoldur();
                

                id = id.Decrypt();
                var ogrenci = await _kullaniciService.OgrenciGetir(Convert.ToInt32(id));

                if (ogrenci == null)
                {
                    //TempData["Mesaj"] = ogrenci.Message;
                    return RedirectToAction("UyeListele");
                }

                ViewBag.OgrenciNo = id;

                var _kullanici = _mapper.Map<KullaniciDto>(ogrenci.Data);
                
                await OgrenciSinifDoldur(_kullanici.Id);

                ogrenci.Data.SinifId = _ogrenciSinifId;

                //ogrenci.Data.SinifId = ViewBag.OgrenciSinifListesi

                //var ogrenciSiniflar = await _ogrenciSinifService.OgrenciSiniflariGetir(_kullanici.Id);
                //_kullanici.SinifId = ogrenciSiniflar.LastOrDefault().SinifId;

                var sonuc = await _ogrenciGorevTakipService.OgrenciGorevTakipGetir(Convert.ToInt32(id));

                var calenderDto = new List<CalenderDto>();

                foreach (var item in sonuc)
                {
                    calenderDto.Add(new CalenderDto()
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

                _kullanici.EncryptedId = _kullanici.Id.Encrypt();
                model.Ogrenci = _kullanici;
                model.GorevListesi = calenderDto;


                SinavTakipViewModel sinavTakipViewModel = new SinavTakipViewModel();

                sinavTakipViewModel.araViewModel.OgrenciId = Convert.ToInt32(id);

                var page = sinavTakipViewModel.araViewModel.request.Page;
                if (page == 0) page = 1;

                sinavTakipViewModel.araViewModel.request = new PagerRequest();
                sinavTakipViewModel.araViewModel.request.Page = page;
                sinavTakipViewModel.araViewModel.request.PageSize = _pageSize;

                var sinavTakipSonuc = await _ogrenciSinavTakipService.OgrenciSinavTakipGetir(sinavTakipViewModel.araViewModel);
                if (sinavTakipSonuc.Items.Count == 0)
                {
                    sinavTakipViewModel.PageInfo.TotalItems = 1;
                    sinavTakipViewModel.PageInfo.ItemsPerPage = 1;
                }
                else
                {
                    foreach (var _sonuc in sinavTakipSonuc.Items)
                    {
                        _sonuc.EncryptedId = _sonuc.Id.Encrypt();
                    }
                }

                sinavTakipViewModel.Model = sinavTakipSonuc;
                sinavTakipViewModel.PageInfo.CurrentPage = page;
                sinavTakipViewModel.PageInfo.TotalItems = sinavTakipViewModel.Model.TotalItems;
                sinavTakipViewModel.PageInfo.ItemsPerPage = _pageSize;

                model.SinavTakipViewModel = sinavTakipViewModel;

                //var uyeBilgileri = uye.Data;

                //GenclikMerkeziDoldur(uyeBilgileri.Genclik_Merkezi_Id);

                //uyeGuncelleViewModel.Uye = uyeBilgileri;

                //uyeGuncelleViewModel = UyelikBilgileriDoldur(uyeGuncelleViewModel);

                //uyeGuncelleViewModel = GencFaaliyetBilgileriDoldur(uyeGuncelleViewModel);

                //#region Veli izin tabı dolduruluyor
                //var _veliIzinleri = Api.GetMethod<List<VeliIzinDto>>("/VeliIzin/UyeIdIleVeliIzinGetir?uyeId=" + uyeBilgileri.Id, GetToken(), null);
                //uyeGuncelleViewModel.VeliIzinleri = _veliIzinleri;
                //#endregion

                //#region Tarihçe tabı dolduruluyor
                //var _tarihceler = Api.GetMethod<List<UyeTarihceDto>>("/UyeTarihce/UyeIdIleUyeTarihceGetir?uyeId=" + uyeBilgileri.Id, GetToken(), null);
                //if (_tarihceler == null)
                //{
                //    uyeGuncelleViewModel.Tarihce = new List<UyeTarihceDto>();
                //}
                //else
                //{
                //    uyeGuncelleViewModel.Tarihce = _tarihceler;
                //}
                //#endregion

                //#region Öğremin tabı dolduruluyor
                //uyeGuncelleViewModel.OgrenimVM.Tc_Kimlik_No = uye.Data.Kisi.Tc_Kimlik_No;
                //uyeGuncelleViewModel.OgrenimVM.Ogrenim_Durumlari = OgrenimDurumuGetir("MEB");
                //uyeGuncelleViewModel.OgrenimVM.Iller = IlGetir();
                //var _ogrenimler = Api.GetMethod<List<KisiOgrenimDto>>("/KisiOgrenim/UyeIdIleOgrenimGetir?uyeId=" + uyeBilgileri.Id, GetToken(), null);
                //uyeGuncelleViewModel.OgrenimVM.Ogrenimler = _ogrenimler;
                //uyeGuncelleViewModel.OgrenimVM.Kisi_Id = uye.Data.Kisi.Id;
                //uyeGuncelleViewModel.OgrenimVM.Uye_Id = uye.Data.Id;
                //#endregion

                return View(model);
            }
            return View(model);
        }

        public async Task<IActionResult> OgrenciSil(string id)
        {
            var _id = EncryptDecrypExt.Decrypt(id);

            var _ogrenci = await _kullaniciService.GetByIdAsync(Convert.ToInt32(_id));

            if (_ogrenci == null)
            {
                TempData["Durum"] = "False";
                TempData["Mesaj"] = "Kayıt bulunamadı..!!";
            }
            else
            {
                _ogrenci.Silindi = true;
                var sonuc = _kullaniciService.Update(_ogrenci);
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
            return Redirect("/DanismanPanel/Ogrenci/OgrenciListele");

        }

        async Task OgrenciSinifDoldur(int ogrenciId)
        {
            var ogrenciSiniflar = await _ogrenciSinifService.OgrenciSiniflariGetir(ogrenciId);

            IEnumerable<SelectListItem> itemsOgrenciSiniflar = ogrenciSiniflar.Select(s => new SelectListItem
            {
                Value = s.SinifId.ToString(),
                Text = s.SinifAdi
            });
            _ogrenciSinifId = ogrenciSiniflar.OrderByDescending(o => o.SinifId).Select(s => s.SinifId).FirstOrDefault();
            ViewBag.OgrenciSinifListesi = itemsOgrenciSiniflar;
        }

        [HttpPost]
        public async Task<IActionResult> OgrenciGuncelle(KullaniciDto kullaniciDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    kullaniciDto.Id = Convert.ToInt32(kullaniciDto.EncryptedId.Decrypt());

                    if (_ogrenciSinifId != kullaniciDto.SinifId)
                    {
                        var ogrenciSiniflar = await _ogrenciSinifService.OgrenciSiniflariGetir(kullaniciDto.Id);
                        if (ogrenciSiniflar.Where(w => w.SinifId == kullaniciDto.SinifId).FirstOrDefault() == null)
                        {
                            OgrenciSinifDto ogrenciSinifDto = new OgrenciSinifDto();
                            ogrenciSinifDto.SinifId = kullaniciDto.SinifId;
                            ogrenciSinifDto.OgrenciId = kullaniciDto.Id;
                            var sonuc = await _ogrenciSinifService.AddAsync(_mapper.Map<OgrenciSinif>(ogrenciSinifDto));
                        }
                        else
                        {
                            kullaniciDto.SinifId = _ogrenciSinifId;
                            TempData["Durum"] = "False";
                            TempData["Mesaj"] = "Ogrencinin sınıf bilgisi daha önce oluşturulmuş..!!";
                            return new RedirectResult(Url.Action("OgrenciDetay", new { id = kullaniciDto.Id.Encrypt() }));
                        }
                    }


                    var danismanId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);

                    kullaniciDto.IslemYapanKullanici = danismanId;
                    kullaniciDto.IslemTarihi = DateTime.Now;
                    //var sonuc = _kullaniciService.Update(_mapper.Map<Kullanici>(kullaniciDto));

                    TempData["Mesaj"] = "Güncelleme işlemi başarılı bir şekilde yapıldı..!!";
                }
                catch (Exception ex)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = ex.ToString();
                }
            }
            return new RedirectResult(Url.Action("OgrenciDetay", new { id = kullaniciDto.Id.Encrypt() }));
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
            return new RedirectResult(Url.Action("OgrenciDetay", new { id = ogrenciGorevTakipDto.OgrenciId.Encrypt() }) + "#tab_3");
            //return Redirect("OgrenciDetay?id=" + ogrenciGorevTakipDto.OgrenciId.Encrypt() + "#tab_3");
            //return new RedirectResult(Url.Action("OgrenciDetay") + "?id=" + ogrenciGorevTakipDto.OgrenciId.Encrypt() + "#tab_3");
        }

        [HttpPost]
        public async Task<IActionResult> DanismanRaporuEkle(OgrenciDokumanDto ogrenciDokumanDto)
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
                            Upload_Yolu = "wwwroot/Panel/Files/Danisman-Raporu",
                            Mb = 3
                        };

                        var dokumanUpload = FileUploadExt.DokumanUpload(fileUploadDto);

                        if (dokumanUpload.Data == null)
                        {
                            TempData["Durum"] = "False";
                            TempData["Mesaj"] = dokumanUpload.Message;
                            return new RedirectResult(Url.Action("OgrenciDetay", new { id = ogrenciDokumanDto.OgrenciId.Encrypt() }) + "#tab_5");
                        }
                        ogrenciDokumanDto.Dokuman = dokumanUpload.Data.Dokuman;
                    }


                    var danismanId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);

                    ogrenciDokumanDto.DokumanAdi = ogrenciDokumanDto.Dosya.FileName;
                    ogrenciDokumanDto.IslemYapanKullanici = danismanId;
                    ogrenciDokumanDto.IslemTarihi = DateTime.Now;
                    ogrenciDokumanDto.Aktif = true;
                    ogrenciDokumanDto.DokumanKategori = Shared.Enums.OgrenciDokumanKategoriEnum.DanismanRaporu;

                    ogrenciDokumanDto.Dosya = null;

                    var sonuc = await _ogrenciDokumanService.AddAsync(_mapper.Map<OgrenciDokuman>(ogrenciDokumanDto));
                    if (sonuc != null)
                    {
                        TempData["Mesaj"] = "Öğrenci raporu başarılı bir şekilde eklendi..!!";
                        return new RedirectResult(Url.Action("OgrenciDetay", new { id = ogrenciDokumanDto.OgrenciId.Encrypt() }) + "#tab_5");
                    }
                }
                catch (Exception ex)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = ex.ToString();
                }
            }
            return new RedirectResult(Url.Action("OgrenciDetay", new { id = ogrenciDokumanDto.OgrenciId.Encrypt() }) + "#tab_5");
        }


        [HttpPost]
        public async Task<IActionResult> DokumanEkle(OgrenciDokumanDto ogrenciDokumanDto)
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
                            Upload_Yolu = "wwwroot/Panel/Files/Dokuman",
                            Mb = 3
                        };

                        var dokumanUpload = FileUploadExt.DokumanUpload(fileUploadDto);

                        if (dokumanUpload.Data == null)
                        {
                            TempData["Durum"] = "False";
                            TempData["Mesaj"] = dokumanUpload.Message;
                            return new RedirectResult(Url.Action("OgrenciDetay", new { id = ogrenciDokumanDto.OgrenciId.Encrypt() }) + "#tab_6");
                        }
                        ogrenciDokumanDto.Dokuman = dokumanUpload.Data.Dokuman;
                        
                    }


                    var danismanId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);

                    ogrenciDokumanDto.DokumanAdi = ogrenciDokumanDto.Dosya.FileName;
                    ogrenciDokumanDto.IslemYapanKullanici = danismanId;
                    ogrenciDokumanDto.IslemTarihi = DateTime.Now;
                    ogrenciDokumanDto.Aktif = true;
                    ogrenciDokumanDto.DokumanKategori = Shared.Enums.OgrenciDokumanKategoriEnum.Dokumanlar;

                    ogrenciDokumanDto.Dosya = null;

                    var sonuc = await _ogrenciDokumanService.AddAsync(_mapper.Map<OgrenciDokuman>(ogrenciDokumanDto));
                    if (sonuc != null)
                    {
                        TempData["Mesaj"] = "Doküman başarılı bir şekilde eklendi..!!";
                        return new RedirectResult(Url.Action("OgrenciDetay", new { id = ogrenciDokumanDto.OgrenciId.Encrypt() }) + "#tab_6");
                    }
                }
                catch (Exception ex)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = ex.ToString();
                }
            }
            return new RedirectResult(Url.Action("OgrenciDetay", new { id = ogrenciDokumanDto.OgrenciId.Encrypt() }) + "#tab_6");
        }


        [HttpPost]
        public async Task<IActionResult> KaynakOnerisiEkle(OgrenciDokumanDto ogrenciDokumanDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var danismanId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);

                    ogrenciDokumanDto.IslemYapanKullanici = danismanId;
                    ogrenciDokumanDto.IslemTarihi = DateTime.Now;
                    ogrenciDokumanDto.Aktif = true;
                    ogrenciDokumanDto.DokumanKategori = Shared.Enums.OgrenciDokumanKategoriEnum.KaynakOnerisi;

                    var sonuc = await _ogrenciDokumanService.AddAsync(_mapper.Map<OgrenciDokuman>(ogrenciDokumanDto));
                    if (sonuc != null)
                    {
                        TempData["Mesaj"] = "Kaynak önerisi başarılı bir şekilde eklendi..!!";
                        return new RedirectResult(Url.Action("OgrenciDetay", new { id = ogrenciDokumanDto.OgrenciId.Encrypt() }) + "#tab_7");
                    }
                }
                catch (Exception ex)
                {
                    TempData["Durum"] = "False";
                    TempData["Mesaj"] = ex.ToString();
                }
            }
            return new RedirectResult(Url.Action("OgrenciDetay", new { id = ogrenciDokumanDto.OgrenciId.Encrypt() }) + "#tab_7");
        }


    }
}
