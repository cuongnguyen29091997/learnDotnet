using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Components
{
    public class CategoryComponent : ViewComponent
    {
        private BookService _bookService;

        public CategoryComponent(BookService bookService)
        {
            _bookService = bookService;
        }

        public IViewComponentResult Invoke()
        {
            List<Category> categories = _bookService.getAllCategories();
            Console.WriteLine(categories);
            return View(categories);
        }
    }
}