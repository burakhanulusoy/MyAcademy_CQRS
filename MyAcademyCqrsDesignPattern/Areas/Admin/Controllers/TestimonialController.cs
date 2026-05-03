using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.TestimonialCommands;
using MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.TestimonialHandlers;
using MyAcademyCqrsDesignPattern.CqrsPattern.Queries.TestimonailQueries;

namespace MyAcademyCqrsDesignPattern.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController(CreateTestimonialCommandHandler _createTestimonialCommandHandler,
                                       UpdateTestimonialCommandHandler _updateTestimonialCommandHandler,
                                       RemoveTestimonialCommandHandler _removeTestimonialCommandHandler,
                                       GetTestimonialsQueryHandler     _getTestimonialsQueryHandler,
                                       GetTestimonialByIdQueryHandler  _getTestimonialByIdQueryHandler,
                                       IMapper _mapper) : Controller
    {




        public async Task<IActionResult> Index()
        {
            var items = await _getTestimonialsQueryHandler.Handle();
            return View(items);
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _removeTestimonialCommandHandler.Handle(new RemoveTestimonialCommand(id));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand createTestimonialCommand)
        {
            await  _createTestimonialCommandHandler.Handle(createTestimonialCommand);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var item = await _getTestimonialByIdQueryHandler.Handle(new GetTestimonialByIdQuery(id));

            var mappedItem = _mapper.Map<UpdateTestimonialCommand>(item);

            return View(mappedItem);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand updateTestimonialCommand)
        {

            await _updateTestimonialCommandHandler.Handle(updateTestimonialCommand);
            return RedirectToAction(nameof(Index));


        }



    }
}
