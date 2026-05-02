using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.ProductCommands;
using MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CategoryHandlers;
using MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.ProductHandlers;
using MyAcademyCqrsDesignPattern.CqrsPattern.Queries.ProductQueries;

namespace MyAcademyCqrsDesignPattern.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IMapper mapper,
                                  GetCategoriesQueryHandler _getCategoriesQueryHandler,
                                  IValidator<UpdateProductCommand> _updateValidator,
                                  GetProductsQueryHandler _getProductsQueryHandler,
                                  GetProductByIdQueryHandler _getProductByIdQueryHandler,
                                  UpdateProductCommandHandler _updateProductCommandHandler,
                                  CreateProductCommandHandler _createProductCommandHandler,
                                  RemoveProductCommandHandler _deleteProductCommandHandler) : Controller
    {


        private async Task GetCategoriesAsync()
        {
            var categories = await _getCategoriesQueryHandler.Handle();

            ViewBag.categories = (from item in categories
                                  select new SelectListItem
                                  {
                                      Text=item.Name,
                                      Value=item.Id.ToString()
                                  }).ToList();



        }





        public async Task<IActionResult> Index()
        {
            var products = await _getProductsQueryHandler.Handle();
            return View(products);
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            await GetCategoriesAsync();

            var product = await _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));

            var mappedProduct = mapper.Map<UpdateProductCommand>(product);

            return View(mappedProduct);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            await GetCategoriesAsync();

            var validationResult = await _updateValidator.ValidateAsync(updateProductCommand);
            if (!validationResult.IsValid)
            {

                foreach(var error in  validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(updateProductCommand);

            }



            await _updateProductCommandHandler.Handle(updateProductCommand);

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> CreateProduct()
        {
            await GetCategoriesAsync();
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProductCommand)
        {
            await GetCategoriesAsync();
            await _createProductCommandHandler.Handle(createProductCommand);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> DeleteProduct(int id)
        {

            await _deleteProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction(nameof(Index));



        }







    }
}
