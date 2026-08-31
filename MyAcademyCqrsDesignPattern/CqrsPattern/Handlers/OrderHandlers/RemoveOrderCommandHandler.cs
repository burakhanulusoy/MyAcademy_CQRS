using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.OrderCommands;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.OrderHandlers
{
    public class RemoveOrderCommandHandler(AppDbContext context)
    {
        public async Task Handle(RemoveOrderCommand command)
        {
               var order = await context.Orders.FindAsync(command.Id);
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
            
        }


    }
}
