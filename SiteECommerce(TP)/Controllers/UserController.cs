using Microsoft.AspNetCore.Mvc;
using SiteECommerce_TP_.Context;
using SiteECommerce_TP_.Models.ViewModels;

namespace SiteECommerce_TP_.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region REGISTER

        // GET: /Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //POST: /Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        #endregion
    }
}
