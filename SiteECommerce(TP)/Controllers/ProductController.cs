using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using SiteECommerce_TP_.Context;
using SiteECommerce_TP_.Models;
using SiteECommerce_TP_.Models.ViewModels;
using SiteECommerce_TP_.DistantData;
using Azure.Core;

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
                ViewData["Role"] = HttpContext.Session.GetString("Role");
            }

            var getAllProducts = _context.Products;
            return View(await getAllProducts.ToListAsync());
        }

        [HttpGet]
        [Route("/Product/Details/{id?}")]
        public async Task<IActionResult> Details(Guid id)
        {
            ViewData["SessionActiveState"] = false;

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionActiveState")))
            {
                ViewData["UserFullname"] = HttpContext.Session.GetString("UserFullname");
                ViewData["SessionActiveState"] = true;
                ViewData["Role"] = HttpContext.Session.GetString("Role");
            }

            Product? product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);

            return View(product);
        }


        [HttpGet]
        [Route("/New-product")]
        public IActionResult AddProduct()
        {
            ViewData["SessionActiveState"] = false;

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionActiveState")))
            {
                ViewData["UserFullname"] = HttpContext.Session.GetString("UserFullname");
                ViewData["SessionActiveState"] = true;
                ViewData["Role"] = HttpContext.Session.GetString("Role");

                return View();  
            }

                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("/New-product")]
        public async Task<IActionResult> AddProduct(AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Add File Verification

                string fileName = Uploader.UploadFile(model.Picture);

                Product newProduct = new()
                {
                    Name = model.ProductName,
                    Height = model.Height,
                    Length = model.Length,
                    Width = model.Width,
                    Weight = model.Weight,
                    Capacity = model.Capacity,
                    Description = model.Description,
                    Color = model.PrimaryColor,
                    Constructor = model.Constructor,
                    Price = model.Price,
                    Picture = fileName
                };
                _context.Products.Add(newProduct);
                await _context.SaveChangesAsync();

                return RedirectToAction("Products");
            }
            return View();
        }
    }
}
