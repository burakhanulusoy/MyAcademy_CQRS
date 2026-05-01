using Microsoft.AspNetCore.Mvc;
using MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CategoryHandlers;
using MyAcademyCqrsDesignPattern.CqrsPattern.Queries.CategoryQueries;
using System.Threading.Tasks;

namespace MyAcademyCqrsDesignPattern.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(GetCategoriesQueryHandler _getCategoriesQueryHandler
                                    ,GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _getCategoriesQueryHandler.Handle();
            return View(categories);
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return View(category);

        }

    }
}
