using Microsoft.AspNetCore.Mvc;
using MonitorShop.Business.Abstract;
using MonitorShop.Entities;

namespace MonitorShop.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            var roles = _roleService.GetAll();

            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Role role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }

            _roleService.Add(role);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var role = _roleService.GetById(id);

            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        [HttpPost]
        public IActionResult Edit(Role role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }

            _roleService.Update(role);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var role = _roleService.GetById(id);

            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var role = _roleService.GetById(id);

            if (role == null)
            {
                return NotFound();
            }

            _roleService.Delete(role);

            return RedirectToAction("Index");
        }
    }
}