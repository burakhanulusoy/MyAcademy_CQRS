using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CategoryCommands;
using MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CategoryHandlers;
using MyAcademyCqrsDesignPattern.CqrsPattern.Queries.CategoryQueries;
using System.Threading.Tasks;

namespace MyAcademyCqrsDesignPattern.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(GetCategoriesQueryHandler _getCategoriesQueryHandler
                                    ,GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler
                                   ,UpdateCategoryCommandHandler _updateCategoryCommand) : Controller
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

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {
           
            await _updateCategoryCommand.Handle(updateCategoryCommand);
            return RedirectToAction(nameof(Index));

        }


    }
}
