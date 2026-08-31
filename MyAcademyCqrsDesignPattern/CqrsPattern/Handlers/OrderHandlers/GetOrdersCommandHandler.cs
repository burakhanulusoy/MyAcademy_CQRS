using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.OrderResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.OrderHandlers
{
    public class GetOrdersCommandHandler(AppDbContext context,IMapper mapper)
    {

        public async Task <List<GetOrdersQueryResult>> Handle()
        {
            var orders = await context.Orders.Include(x=>x.Customer).AsNoTracking().ToListAsync();
            return mapper.Map<List<GetOrdersQueryResult>>(orders);
        }


    }
}
