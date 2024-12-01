using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UzmanEgitimDanismanim.Web.Areas.DanismanPanel.Controllers
{
    [Authorize]
    [Area("DanismanPanel")]
    public class YapimAsamasindaController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}