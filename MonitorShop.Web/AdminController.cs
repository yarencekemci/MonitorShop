using Microsoft.AspNetCore.Mvc;
using MonitorShop.Business.Abstract;

namespace MonitorShop.Web.Controllers
{
    public class AdminController : Controller
    {

        // services used to retrieve data from the business layer
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;


        // constructor injection is used for dependency injection
        public AdminController(
            IProductService productService,
            ICategoryService categoryService,
            IUserService userService,
            IOrderService orderService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userService = userService;
            _orderService = orderService;
        }


        //it gets data from the business layer and sends the total counts to the admin dashboard using viewBag

        public IActionResult Index()
        {
            ViewBag.ProductCount = _productService.GetAll().Count;
            ViewBag.CategoryCount = _categoryService.GetAll().Count;
            ViewBag.UserCount = _userService.GetAll().Count;
            ViewBag.OrderCount = _orderService.GetAll().Count;

            return View();
        }
    }
}