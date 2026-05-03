using AutoMapper;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.TestimonialCommands;
using MyAcademyCqrsDesignPattern.Entities;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler(AppDbContext _context,IMapper  _mapper)
    {
        public async Task Handle(UpdateTestimonialCommand updateTestimonialCommand)
        {

            var item = _mapper.Map<Testimonial>(updateTestimonialCommand);
            _context.Update(item);
            await _context.SaveChangesAsync();

        }




    }
}
