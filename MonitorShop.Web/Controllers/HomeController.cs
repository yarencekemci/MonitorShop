using Microsoft.AspNetCore.Mvc;
using MonitorShop.Business.Abstract;

namespace MonitorShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll();

            return View(products);
        }
    }
}