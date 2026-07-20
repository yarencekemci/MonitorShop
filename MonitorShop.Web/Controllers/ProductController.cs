using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MonitorShop.Business.Abstract;
using MonitorShop.Entities;

namespace MonitorShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(
            IProductService productService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _productService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryService.GetAll();

            ViewBag.Categories = new SelectList(
                categories,
                "Id",
                "Name"
            );

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productService.Add(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetById(id);
            var categories = _categoryService.GetAll();

            ViewBag.Categories = new SelectList(
                categories,
                "Id",
                "Name",
                product.CategoryId
            );

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _productService.Update(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            _productService.Delete(product);

            return RedirectToAction("Index");
        }
    }
}