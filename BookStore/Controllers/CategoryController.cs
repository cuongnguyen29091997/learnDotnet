using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
