using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MonitorShop.Business.Abstract;
using MonitorShop.Entities;

namespace MonitorShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrderController(
            IOrderService orderService,
            IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var orders = _orderService.GetAll();

            return View(orders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadUsers();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            ModelState.Remove("User");
            ModelState.Remove("OrderDetails");

            if (!ModelState.IsValid)
            {
                LoadUsers(order.UserId);

                return View(order);
            }

            _orderService.Add(order);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = _orderService.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            LoadUsers(order.UserId);

            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            ModelState.Remove("User");
            ModelState.Remove("OrderDetails");

            if (!ModelState.IsValid)
            {
                LoadUsers(order.UserId);

                return View(order);
            }

            _orderService.Update(order);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var order = _orderService.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _orderService.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            _orderService.Delete(order);

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
    }
}