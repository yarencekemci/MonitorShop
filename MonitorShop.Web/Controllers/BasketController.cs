using Microsoft.AspNetCore.Mvc;

namespace MonitorShop.Web.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}