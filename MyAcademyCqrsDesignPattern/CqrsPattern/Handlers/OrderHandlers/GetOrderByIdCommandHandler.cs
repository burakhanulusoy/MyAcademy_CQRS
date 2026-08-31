using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Queries.OrderQueries;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.OrderResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.OrderHandlers
{
    public class GetOrderByIdCommandHandler(AppDbContext _context,IMapper mapper)
    {

        public async Task <GetOrderByIdQueryResult> Handle(GetOrderByIdQuery query)
        {
          
            var order = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == query.Id);

            return mapper.Map<GetOrderByIdQueryResult>(order);
            


        }


    }
}
