using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCqrsDesignPattern.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
