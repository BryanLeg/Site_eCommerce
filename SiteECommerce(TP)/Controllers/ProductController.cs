using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteECommerce_TP_.Context;

namespace SiteECommerce_TP_.Controllers
{
    public class ProductController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Products()
        {
            var getAllProducts = _context.Products;
            return View(await getAllProducts.ToListAsync());
        }
    }
}
