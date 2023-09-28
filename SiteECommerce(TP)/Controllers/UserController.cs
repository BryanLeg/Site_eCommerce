using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteECommerce_TP_.Context;
using SiteECommerce_TP_.Models;
using SiteECommerce_TP_.Models.ViewModels;
using BC = BCrypt.Net.BCrypt;

namespace SiteECommerce_TP_.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region REGISTER

        [HttpGet]
        [Route("/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("/Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                if(model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Passwords don't match");
                    return View();
                }

                var existingEmail = _context.Users.FirstOrDefault(
                    user => user.Mail == model.Email
                );

                if(existingEmail != null)
                {
                    ModelState.AddModelError("", "This email already exists.");
                    return View();
                }


                User newUser = new ()
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Password = BC.HashPassword(model.Password),
                    Mail = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Adress,
                    City = model.City,
                    Country = model.Country,
                    PostalCode = model.PostalCode
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            return View();
        }


        #endregion

        #region LOGIN
        [HttpGet]
        [Route("/Login")]
        public IActionResult Login()
        {
            ViewData["SessionActiveState"] = false;

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionActiveState")))
            {
                ViewData["UserFullname"] = HttpContext.Session.GetString("UserFullname");
                ViewData["SessionActiveState"] = true;
            }

            string? session = HttpContext.Session.GetString("SessionActiveState");
            if (session == "true")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [Route("/Login")]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var confirmedUser = _context.Users.FirstOrDefault(user => user.Mail == model.Email);

                if ( confirmedUser != null && BC.Verify(model.Password, confirmedUser.Password))
                {
                    if(string.IsNullOrEmpty(HttpContext.Session.GetString("UserFullname")))
                    {
                        HttpContext.Session.SetString("UserId", confirmedUser.Id.ToString());
                        HttpContext.Session.SetString("UserFullname", confirmedUser.Firstname + confirmedUser.Lastname);
                        HttpContext.Session.SetString("Role", confirmedUser.Role);
                        HttpContext.Session.SetString("SessionActiveState", "true");
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect email or password");
                return View();
            }

            return View();
        }

        #endregion

        #region LOG OUT
        [HttpGet]
        [Route("/Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        #endregion

        #region GET USERS
        [HttpGet]
        [Route("/Users")]
        public async Task<IActionResult> Users()
        {
            ViewData["SessionActiveState"] = false;

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionActiveState")))
            {
                ViewData["UserFullname"] = HttpContext.Session.GetString("UserFullname");
                ViewData["SessionActiveState"] = true;

            }

            if (HttpContext.Session.GetString("Role") == "Admin")
            {
                var getAllUsers = _context.Users;
                return View(await getAllUsers.ToListAsync());

            }

                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("/User/Details/{id?}")]
        public async Task<IActionResult> Details(Guid id)
        {
            ViewData["SessionActiveState"] = false;

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionActiveState")))
            {
                ViewData["UserFullname"] = HttpContext.Session.GetString("UserFullname");
                ViewData["SessionActiveState"] = true;

            }

            if(HttpContext.Session.GetString("Role") == "Admin")
            {
                User? user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

                return View(user);

            }
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region EDIT USER
        [HttpGet]
        [Route("/User/Edit/{id?}")]
        public async Task<IActionResult> EditUser(Guid id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionActiveState")))
            {
                ViewData["UserFullname"] = HttpContext.Session.GetString("UserFullname");
                ViewData["SessionActiveState"] = true;

            }

            if (HttpContext.Session.GetString("Role") == "Admin")
            {
                User? user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

                ViewData["User"] = user;

                var model = new EditUserViewModel();
                model.Role = user.Role;

                return View(model);

            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [Route("/User/Edit/{id?}")]
        public async Task<IActionResult> EditUser(Guid id, [Bind("Firstname, Lastname, Mail, PhoneNumber, Address, City, Country, PostalCode, Role")] EditUserViewModel model)
        {
                Guid InEditUserID = (Guid)TempData["InEditUserID"];
            if(ModelState.IsValid)
            {
                //User editedUser = new()
                //{
                //    Firstname = model.Firstname,
                //    Lastname = model.Lastname,
                //    Mail = model.Email,
                //    PhoneNumber = model.PhoneNumber,
                //    Address = model.Adress,
                //    City = model.City,
                //    Country = model.Country,
                //    PostalCode = model.PostalCode,
                //    Role = model.Role
                //};


                //User? existingUser = _context.Users.FirstOrDefault(user => user.Id == InEditUserID);

                _context.Update(model);
                await _context.SaveChangesAsync();

                Console.WriteLine("form edited");

                return RedirectToAction("Details" , new{ id = InEditUserID});
            }
            return RedirectToAction("EditUser", new { id = InEditUserID });
        }
        #endregion
    }
}
