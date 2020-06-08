using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService;
        private readonly ILogger<BookController> _logger;
        public BookController(ILogger<BookController> logger,BookService bookService)
        {
            this._logger = logger;
            _bookService = bookService;
        }
        [HttpGet("/[controller]/[action]/{catId}/{page=1}")]
        public IActionResult Category(int catId, int page = 1)
        {
            Console.WriteLine(catId.ToString());
            int totalbook  = _bookService.countBooksByCategory(catId);
            ViewData["fromBook"] = BookService.PageSize * (page - 1) + 1;
            ViewData["toBook"] = Math.Min(BookService.PageSize * page, totalbook);
            ViewData["totalBook"] = totalbook;
            ViewData["currentPage"] = page;
            ViewData["categoryId"] = catId;
            ViewData["endPage"] = (int)Math.Round((float)(totalbook + BookService.PageSize - 1) / BookService.PageSize);
            ViewData.Model = _bookService.getBookByCategoryAndPage(catId, page);
            return View();
        }
    }
}
