using AutoMapper;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.ProductCommands;
using MyAcademyCqrsDesignPattern.Entities;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler(AppDbContext _context,IMapper _mapper)
    {

        public async Task Handle(CreateProductCommand createProductCommand)
        {
            var mappedProduct = _mapper.Map<Product>(createProductCommand);

            await _context.Products.AddAsync(mappedProduct);

            await _context.SaveChangesAsync();


        }






    }
}
