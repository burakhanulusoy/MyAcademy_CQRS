using AutoMapper;
using FluentValidation;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CategoryCommands;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CustomerCommands;
using MyAcademyCqrsDesignPattern.Entities;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CustomerHandlers
{
    public class CreateCustomerCommandHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(AppDbContext context, IMapper mapper, IValidator<CreateCategoryCommand> validator)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Handle(CreateCustomerCommand command)
        {
            
               var mappedCustomer = _mapper.Map<Customer>(command);
                await _context.Customers.AddAsync(mappedCustomer);
                await _context.SaveChangesAsync();




        }





    }
}
