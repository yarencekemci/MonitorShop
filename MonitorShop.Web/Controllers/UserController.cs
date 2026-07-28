using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MonitorShop.Business.Abstract;
using MonitorShop.Entities;

namespace MonitorShop.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(
            IUserService userService,
            IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAll();

            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadRoles();

            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            // Bu alanlar formdan gönderilmediği için kontrolden çıkarılır.
            ModelState.Remove("Role");
            ModelState.Remove("Orders");
            ModelState.Remove("Baskets");

            if (!ModelState.IsValid)
            {
                LoadRoles(user.RoleId);

                return View(user);
            }

            _userService.Add(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            LoadRoles(user.RoleId);

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            // Bu alanlar formdan gönderilmediği için kontrolden çıkarılır.
            ModelState.Remove("Role");
            ModelState.Remove("Orders");
            ModelState.Remove("Baskets");

            if (!ModelState.IsValid)
            {
                LoadRoles(user.RoleId);

                return View(user);
            }

            _userService.Update(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Delete(user);

            return RedirectToAction("Index");
        }

        private void LoadRoles(int? selectedRoleId = null)
        {
            var roles = _roleService.GetAll();

            ViewBag.Roles = new SelectList(
                roles,
                "Id",
                "Name",
                selectedRoleId
            );
        }
    }
}