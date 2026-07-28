using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MonitorShop.Business.Abstract;
using MonitorShop.Entities;

namespace MonitorShop.Web.Controllers
{
    public class BasketAdminController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public BasketAdminController(
            IBasketService basketService,
            IUserService userService,
            IProductService productService)
        {
            _basketService = basketService;
            _userService = userService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var baskets = _basketService.GetAll();

            return View(baskets);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadUsers();
            LoadProducts();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Basket basket)
        {
            ModelState.Remove("User");
            ModelState.Remove("Product");

            if (!ModelState.IsValid)
            {
                LoadUsers(basket.UserId);
                LoadProducts(basket.ProductId);

                return View(basket);
            }

            _basketService.Add(basket);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var basket = _basketService.GetById(id);

            if (basket == null)
            {
                return NotFound();
            }

            LoadUsers(basket.UserId);
            LoadProducts(basket.ProductId);

            return View(basket);
        }

        [HttpPost]
        public IActionResult Edit(Basket basket)
        {
            ModelState.Remove("User");
            ModelState.Remove("Product");

            if (!ModelState.IsValid)
            {
                LoadUsers(basket.UserId);
                LoadProducts(basket.ProductId);

                return View(basket);
            }

            _basketService.Update(basket);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var basket = _basketService.GetById(id);

            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var basket = _basketService.GetById(id);

            if (basket == null)
            {
                return NotFound();
            }

            _basketService.Delete(basket);

            return RedirectToAction("Index");
        }

        private void LoadUsers(int? selectedUserId = null)
        {
            ViewBag.Users = new SelectList(
                _userService.GetAll(),
                "Id",
                "FullName",
                selectedUserId);
        }

        private void LoadProducts(int? selectedProductId = null)
        {
            ViewBag.Products = new SelectList(
                _productService.GetAll(),
                "Id",
                "Name",
                selectedProductId);
        }
    }
}