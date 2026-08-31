using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Queries.CustomerQueries;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.CustomerResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CustomerHandlers
{
    public class GetCustomerByIdQueryHandler
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCustomerByIdQueryResult> Handle(GetCustomerByIdQuery query)
        {

            var customer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == query.Id);
            return _mapper.Map<GetCustomerByIdQueryResult>(customer);



        }



    }
}
