using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.CustomerResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CustomerHandlers
{
    public class GetCustomersQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetCustomersQueryResult>> Handle()
        {
            var customers = await _context.Customers.AsNoTracking().ToListAsync();
            return _mapper.Map<List<GetCustomersQueryResult>>(customers);
        }


    }
}
