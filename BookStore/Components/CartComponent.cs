using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Controllers;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Components
{
    public class CartComponent : ViewComponent
    {
        private BookService _bookService;

        public CartComponent(BookService bookService)
        {
            _bookService = bookService;
        }
        public IViewComponentResult Invoke()
        {
            var bookIds = CardHelper.GetAllProducts(HttpContext);
            var books = _bookService.FindAll(bookIds);
            var total = 0.0;
            foreach(var bookD in books) {
                total += bookD.Value * bookD.Key.Price;
            }
            ViewData.Model = books;
            ViewData["quantity"] = bookIds.Count;
            ViewData["total"] = total;

            var username = HttpContext.Session.GetString("userId");
            ViewData["username"] = null;
            if(username != null && !username.Equals("")) {
                ViewData["username"] = username;
            }
            return View();
        }
    }
}