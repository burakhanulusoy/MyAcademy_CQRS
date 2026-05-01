using Mapster;
using Microsoft.EntityFrameworkCore;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Queries.CategoryQueries;
using MyAcademyCqrsDesignPattern.CqrsPattern.Results.CategoryResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler(AppDbContext _context)
    {
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {

            var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == query.Id);

            return category.Adapt<GetCategoryByIdQueryResult>();

        }


    }
}
