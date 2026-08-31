using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Queries.CustomerQueries;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.CustomerResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CustomerHandlers
{
    public class GetCustomersByIdWiithOrdersQueryHandler(AppDbContext context,IMapper mapper)
    {

        public async Task<GetCustomersWithOrdersQueryResult> Handle(GetCustomerByIdWithOrdersQuery query)
        {
            var customers= await context.Customers.AsNoTracking().Include(x=>x.Orders).FirstOrDefaultAsync(x=>x.Id==query.Id);

            return mapper.Map<GetCustomersWithOrdersQueryResult>(customers);

        }



    }
}
