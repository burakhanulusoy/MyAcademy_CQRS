using Mapster;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CategoryCommands;
using MyAcademyCqrsDesignPattern.Entities;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly AppDbContext _context;
         
        public CreateCategoryCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCategoryCommand categoryCommand)
        {
            var mappedCategory = categoryCommand.Adapt<Category>();

            await _context.Categories.AddAsync(mappedCategory); 

            await _context.SaveChangesAsync();

        }




    }
}
