using Mapster;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CategoryCommands;
using MyAcademyCqrsDesignPattern.Entities;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly AppDbContext _context;

        public UpdateCategoryCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {

            var mappedCategory = command.Adapt<Category>();
            _context.Categories.Update(mappedCategory);
            await _context.SaveChangesAsync();

        }




    }
}
