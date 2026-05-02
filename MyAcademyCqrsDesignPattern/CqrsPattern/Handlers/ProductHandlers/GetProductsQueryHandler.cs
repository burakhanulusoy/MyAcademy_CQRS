using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.ProductResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.ProductHandlers
{
    public class GetProductsQueryHandler(AppDbContext _context,IMapper _mapper)
    {

        public async Task<List<GetProductsQueryResult>> Handle()
        {
            var prducts = await _context.Products.Include(x=>x.Category).AsNoTracking().ToListAsync();
            
            return _mapper.Map<List<GetProductsQueryResult>>(prducts);
         

        }



    }
}
