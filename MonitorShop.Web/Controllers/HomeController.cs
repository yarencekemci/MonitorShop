using Microsoft.AspNetCore.Mvc;

namespace MonitorShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
