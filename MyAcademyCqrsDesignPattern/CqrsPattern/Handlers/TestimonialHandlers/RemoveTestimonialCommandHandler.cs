using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.TestimonialCommands;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler(AppDbContext _context)
    {


        public async Task Handle(RemoveTestimonialCommand removeTestimonialCommand)
        {
            var item = await _context.Testimonials.FindAsync(removeTestimonialCommand.id);

            _context.Testimonials.Remove(item);

            await _context.SaveChangesAsync();
        }




    }
}
