using MonitorShop.Entities;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetById(id);
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);

            _productService.Delete(product);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productService.Add(product);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _productService.Update(product);
            return RedirectToAction("Index");
        }
    }
}