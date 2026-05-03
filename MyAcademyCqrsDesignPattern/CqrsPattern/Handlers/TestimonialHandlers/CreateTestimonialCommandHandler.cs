using AutoMapper;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.TestimonialCommands;
using MyAcademyCqrsDesignPattern.Entities;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler(AppDbContext _context,IMapper _mapper)
    {

        public async Task Handle(CreateTestimonialCommand createTestimonialCommand)
        {
            var item = _mapper.Map<Testimonial>(createTestimonialCommand);
           
            await _context.AddAsync(item);
       
            await _context.SaveChangesAsync();


        }





    }
}
