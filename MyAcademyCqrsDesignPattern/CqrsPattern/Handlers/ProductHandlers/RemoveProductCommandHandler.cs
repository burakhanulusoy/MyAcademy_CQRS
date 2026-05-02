using AutoMapper;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.ProductCommands;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler(AppDbContext _context,IMapper _mapper)
    {

        public async Task Handle(RemoveProductCommand deleteProductCommand)
        {

            var product = await _context.Products.FindAsync(deleteProductCommand.Id);
            
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();



        }




    }
}
