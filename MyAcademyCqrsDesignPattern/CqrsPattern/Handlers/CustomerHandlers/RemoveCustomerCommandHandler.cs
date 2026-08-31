using MyAcademyCqrsDesignPattern.Context;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CustomerCommands;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Handlers.CustomerHandlers
{
    public class RemoveCustomerCommandHandler
    {
        private readonly AppDbContext _context;

        public RemoveCustomerCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCustomerCommand command)
        {
            var customer = await _context.Customers.FindAsync(command.Id);

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();



        }




    }
}
