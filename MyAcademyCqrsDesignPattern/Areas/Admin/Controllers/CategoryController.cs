using Microsoft.AspNetCore.Mvc;
using MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CategoryHandlers;
using System.Threading.Tasks;

namespace MyAcademyCqrsDesignPattern.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(GetCategoriesQueryHandler _getCategoriesQueryHandler) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _getCategoriesQueryHandler.Handle();
            return View(categories);
        }



    }
}
