using Mapster;
using Microsoft.EntityFrameworkCore;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.CategoryResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CategoryHandlers
{
    public class GetCategoriesQueryHandler(AppDbContext _context)//app
    {

        public async Task<List<GetCategoriesQueryResult>> Handle()
        {

            var categories = await _context.Categories.AsNoTracking().ToListAsync();

            return categories.Adapt<List<GetCategoriesQueryResult>>();


            ////MANUEL MAPLEME
            //return categories.Select(x => new GetCategoriesQueryResult
            //{
            //    Id = x.Id,
            //    Name = x.Name

            //}).ToList();

       
        
        }






    }
}
