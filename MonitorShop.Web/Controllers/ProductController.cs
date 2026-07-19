using Microsoft.AspNetCore.Mvc;
using MonitorShop.Business.Abstract;

namespace MonitorShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var values = _productService.GetAll();
            return View(values);
        }
    }
}