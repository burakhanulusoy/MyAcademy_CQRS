using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.OrderCommands;
using MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CustomerHandlers;
using MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.OrderHandlers;
using MyAcademyCqrsDesignPattern.CqrsPattern.Queries.OrderQueries;
using System.Threading.Tasks;

namespace MyAcademyCqrsDesignPattern.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController(IMapper _mapper,
                                 GetOrdersCommandHandler getOrdersCommandHandler,
                                 GetOrderByIdCommandHandler getOrderByIdCommandHandler,
                                 CreateOrderCommandHandler createOrderCommandHandler,
                                 UpdateOrderCommandHandler updateOrderCommandHandler,
                                 RemoveOrderCommandHandler removeOrderCommandHandler,
                                 GetCustomersQueryHandler getCustomersQueryHandler,
                                 IValidator<UpdateOrderCommand> updateValidator,
                                 IValidator<CreateOrderCommand> createValidator) : Controller
    {


        private async Task getCustomers()

        {

            var customers = await getCustomersQueryHandler.Handle();
            ViewBag.Customers = (from item in customers
                                 select new SelectListItem
                                 {
                                     Text = item.NameSurname
                                     ,
                                     Value = item.Id.ToString()
                                 }).ToList();



        }

        public async Task<IActionResult> Index()
        {
            var orders = await getOrdersCommandHandler.Handle();
            return View(orders);
        }


        public async Task<IActionResult> UpdateOrder(int id)
        {
            await getCustomers();
            var order = await getOrderByIdCommandHandler.Handle(new GetOrderByIdQuery(id));
            var mappedOrder = _mapper.Map<UpdateOrderCommand>(order);
            return View(mappedOrder);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            var validationResult = await updateValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                await getCustomers();
                return View(command);

            }


            await updateOrderCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> CreateOrder()
        {
            await getCustomers();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            var validationResult = await createValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                await getCustomers();
                return View(command);
            }
            await createOrderCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> RemoveOrder(int id)
        {
            await removeOrderCommandHandler.Handle(new RemoveOrderCommand(id));
            return RedirectToAction("Index");



        }
    }
}