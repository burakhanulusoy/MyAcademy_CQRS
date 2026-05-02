using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CategoryCommands;
using MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CategoryHandlers;
using MyAcademyCqrsDesignPattern.CqrsPattern.Queries.CategoryQueries;

namespace MyAcademyCqrsDesignPattern.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(GetCategoriesQueryHandler _getCategoriesQueryHandler
                                    ,GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler
                                   ,UpdateCategoryCommandHandler _updateCategoryCommand
                                   ,CreateCategoryCommandHandler _createCategoryCommand
                                   ,RemoveCategoryCommandHandler _deleteCategoryCommandHandler
                                   ,IValidator<UpdateCategoryCommand> _updateValidator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _getCategoriesQueryHandler.Handle();
            return View(categories);
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));

            var command = category.Adapt<UpdateCategoryCommand>();

            return View(command);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {

            var validationResult = await _updateValidator.ValidateAsync(updateCategoryCommand);
            if(!validationResult.IsValid)
            {
                foreach(var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(updateCategoryCommand);
            }

            await _updateCategoryCommand.Handle(updateCategoryCommand);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            await _createCategoryCommand.Handle(createCategoryCommand);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _deleteCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return RedirectToAction(nameof(Index));

        }



    }
}
