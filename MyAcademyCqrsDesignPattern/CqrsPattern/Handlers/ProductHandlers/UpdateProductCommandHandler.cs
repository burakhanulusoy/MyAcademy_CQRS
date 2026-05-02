using AutoMapper;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.ProductCommands;
using MyAcademyCqrsDesignPattern.Entities;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler(AppDbContext _context,IMapper _mapper)
    {

        public async Task Handle(UpdateProductCommand updateProdcutCommand)
        {

            var mappedProduct = _mapper.Map<Product>(updateProdcutCommand);

            _context.Products.Update(mappedProduct);

            await _context.SaveChangesAsync();


        }



    }
}
