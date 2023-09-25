﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        // GET: /Register
        [HttpGet]
        [Route("/Register")]
        public IActionResult Register()
        {
            return View();
        }

        //POST: /Register
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


                var newUser = new User
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
                    }
                    Console.WriteLine(HttpContext.Session.GetString("UserFullname"));
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect email or password");
                return View();
            }

            return View();
        }

        #endregion
    }
}
