using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UzmanEgitimDanismanim.Web.Areas.DanismanPanel.Controllers
{
    [Authorize]
    [Area("DanismanPanel")]
    public class SanalCalismaMasasiController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}
