using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.TestimonialResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.TestimonialHandlers
{
    public class GetTestimonialsQueryHandler(AppDbContext _context,IMapper _mapper)
    {
        public async Task<List<GetTestimonialsQueryResult>> Handle()
        {

            var items = await _context.Testimonials.AsNoTracking().ToListAsync();
            return  _mapper.Map<List<GetTestimonialsQueryResult>>(items);


        }


    }
}
