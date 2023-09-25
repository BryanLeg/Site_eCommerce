using Microsoft.AspNetCore.Mvc;
using SiteECommerce_TP_.Models;
using System.Diagnostics;

namespace SiteECommerce_TP_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["UserFullname"] = "";
            ViewData["SessionActiveState"] = false;

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserFullname")))
            {
                ViewData["UserFullname"] = HttpContext.Session.GetString("UserFullname");
                ViewData["SessionActiveState"] = true;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}