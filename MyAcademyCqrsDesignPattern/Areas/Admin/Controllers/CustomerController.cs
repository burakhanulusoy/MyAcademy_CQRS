using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CustomerCommands;
using MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CustomerHandlers;
using MyAcademyCqrsDesignPattern.CqrsPattern.Queries.CustomerQueries;
using System.Threading.Tasks;

namespace MyAcademyCqrsDesignPattern.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController(IValidator<CreateCustomerCommand> _createValidator,
                                    IValidator<UpdateCustomerCommand> _updateValidator,
                                    GetCustomerByIdQueryHandler _getCustomerByIdQueryHandler,
                                    GetCustomersQueryHandler _getCustomersQueryHandler,
                                    CreateCustomerCommandHandler _createCustomerCommandHandler,
                                    UpdateCustomerCommandHandler _updateCustomerCommandHandler,
                                    RemoveCustomerCommandHandler _removeCustomerCommandHandler
                                    ,IMapper _mapper ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var items = await _getCustomersQueryHandler.Handle();
            return View(items);
        }


        public async Task<IActionResult> RemoveCustomer(int id)
        {
            await _removeCustomerCommandHandler.Handle(new RemoveCustomerCommand(id));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand createCustomerCommand)
        {
            var validationResult = _createValidator.Validate(createCustomerCommand);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(createCustomerCommand);
            }
            await _createCustomerCommandHandler.Handle(createCustomerCommand);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var item= await _getCustomerByIdQueryHandler.Handle(new GetCustomerByIdQuery(id));
            var mappedItem = _mapper.Map<UpdateCustomerCommand>(item);
            return View(mappedItem);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommand updateCustomerCommand)
        {
            var validationResult = _updateValidator.Validate(updateCustomerCommand);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(updateCustomerCommand);
            }
            await  _updateCustomerCommandHandler.Handle(updateCustomerCommand);
            return RedirectToAction(nameof(Index));
        }

    }
}
