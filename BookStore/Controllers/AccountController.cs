using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
 
namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDataContext _context;
 
        public AccountController(AppDataContext context)
        {
            _context = context;
        }
 
        public IActionResult Index()
        {
            return View("Login-Register");
        }
        [HttpPost]
        public IActionResult Login()
        {
            if (ModelState.IsValid)
            {
                string email = HttpContext.Request.Form["email"];
                string password = HttpContext.Request.Form["password"];

                var userdetails =  _context.Userdetails.Where(m => m.Email.Equals(email) && m.Password.Equals(password)).FirstOrDefault();
                if (userdetails == null)
                {
                    ViewData["message"] = "Password Invalid login attempt.";
                    return View("Login-Register");
                }
                HttpContext.Session.SetString("userId", userdetails.Name);
            }
            else
            {
                ViewData["message"] = "Username, Password Invalid.";
                return View("Login-Register");
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Register()
        {
            var valid = true;
            string fullName = HttpContext.Request.Form["fullName"];
            string email = HttpContext.Request.Form["email"];
            string password = HttpContext.Request.Form["password"];

            if(fullName.Length < 6 || email.Length < 6 ||password.Length < 6 || 
                fullName.Length > 30 || email.Length > 30 ||password.Length > 30)
                valid = false;
            if(valid) {
                Userdetails user = new Userdetails
                {
                    Name=fullName,
                    Email=email,
                    Password=password,
                };
                _context.Add(user);
                _context.SaveChangesAsync();
            } 
            else
            {
                ViewData["message"] = "Username, Password Invalid.";
                return View("Login-Register");
            }
            return RedirectToAction("Index", "Home");
        }
 
        public  IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login-Register");
        }
    }
}