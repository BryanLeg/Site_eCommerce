using Microsoft.AspNetCore.Mvc;
using SiteECommerce_TP_.Context;

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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }




        #endregion
    }
}
