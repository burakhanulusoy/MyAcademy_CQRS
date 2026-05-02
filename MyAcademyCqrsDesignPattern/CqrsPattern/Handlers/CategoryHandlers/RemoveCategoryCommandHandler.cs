using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CategoryCommands;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler(AppDbContext _context)
    {

        public async Task Handle(RemoveCategoryCommand removeCategoryCommand)
        {
            var category = await _context.Categories.FindAsync(removeCategoryCommand.Id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

        }




    }
}
