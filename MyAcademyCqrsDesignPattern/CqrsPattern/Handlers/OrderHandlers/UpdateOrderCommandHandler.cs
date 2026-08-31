using AutoMapper;
using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.OrderCommands;
using MyAcademyCqrsDesignPattern.Entities;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.OrderHandlers
{
    public class UpdateOrderCommandHandler(AppDbContext context,IMapper mapper)
    {

        public async Task Handle(UpdateOrderCommand command)
        {
            var order = mapper.Map<Order>(command);
            context.Orders.Update(order);
            await context.SaveChangesAsync();

        }


    }
}
