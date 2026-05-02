using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Queries.ProductQueries;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.ProductResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler(AppDbContext _context,IMapper _mapper)
    {
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery getProductByIdQuery)
        {

            var product = await _context.Products.FindAsync(getProductByIdQuery.Id);
            

            return _mapper.Map<GetProductByIdQueryResult>(product);
        }




    }

}
