using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Queries.TestimonailQueries;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.TestimonialResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler(AppDbContext _context , IMapper _mapper)
    {
        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery byIdQuery)
        {

            var item = await _context.Testimonials.AsNoTracking().FirstOrDefaultAsync(x => x.Id == byIdQuery.id);

            return _mapper.Map<GetTestimonialByIdQueryResult>(item);


        }



    }
}
