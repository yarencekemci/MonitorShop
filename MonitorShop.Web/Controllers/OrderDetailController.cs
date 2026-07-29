using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MonitorShop.Business.Abstract;
using MonitorShop.Entities;

namespace MonitorShop.Web.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderDetailController(
            IOrderDetailService orderDetailService,
            IOrderService orderService,
            IProductService productService)
        {
            _orderDetailService = orderDetailService;
            _orderService = orderService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var orderDetails = _orderDetailService.GetAll();

            return View(orderDetails);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadOrders();
            LoadProducts();

            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderDetail orderDetail)
        {
            ModelState.Remove("Order");
            ModelState.Remove("Product");

            if (!ModelState.IsValid)
            {
                LoadOrders(orderDetail.OrderId);
                LoadProducts(orderDetail.ProductId);

                return View(orderDetail);
            }

            _orderDetailService.Add(orderDetail);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var orderDetail = _orderDetailService.GetById(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            LoadOrders(orderDetail.OrderId);
            LoadProducts(orderDetail.ProductId);

            return View(orderDetail);
        }

        [HttpPost]
        public IActionResult Edit(OrderDetail orderDetail)
        {
            ModelState.Remove("Order");
            ModelState.Remove("Product");

            if (!ModelState.IsValid)
            {
                LoadOrders(orderDetail.OrderId);
                LoadProducts(orderDetail.ProductId);

                return View(orderDetail);
            }

            _orderDetailService.Update(orderDetail);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var orderDetail = _orderDetailService.GetById(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var orderDetail = _orderDetailService.GetById(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            _orderDetailService.Delete(orderDetail);

            return RedirectToAction("Index");
        }

        private void LoadOrders(int? selectedOrderId = null)
        {
            ViewBag.Orders = new SelectList(
                _orderService.GetAll(),
                "Id",
                "Id",
                selectedOrderId);
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