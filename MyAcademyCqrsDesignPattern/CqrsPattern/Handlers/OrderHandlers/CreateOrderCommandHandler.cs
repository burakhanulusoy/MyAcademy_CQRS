using AutoMapper;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.OrderCommands;
using MyAcademyCqrsDesignPattern.Entities;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler(AppDbContext context,IMapper mapper)
    {

        public async Task Handle(CreateOrderCommand command)
        {
            var order = mapper.Map<Order>(command);
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }



    }
}
