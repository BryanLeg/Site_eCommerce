using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteECommerce_TP_.Context;
using SiteECommerce_TP_.Models.ViewModels;

namespace SiteECommerce_TP_.Controllers
{
    public class ProductController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/Products")]
        public async Task<IActionResult> Products()
        {
            ViewData["SessionActiveState"] = false;

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionActiveState")))
            {
                ViewData["UserFullname"] = HttpContext.Session.GetString("UserFullname");
                ViewData["SessionActiveState"] = true;
            }

            var getAllProducts = _context.Products;
            return View(await getAllProducts.ToListAsync());
        }

        [HttpGet]
        [Route("/New-product")]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [Route("/New-product")]
        public async Task<IActionResult> AddProduct(AddProductViewModel model)
        {
            return View();
        }
    }
}
