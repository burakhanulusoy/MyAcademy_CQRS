namespace MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CustomerCommands
{
    public class RemoveCustomerCommand
    {
        public int Id { get; set; }

        public RemoveCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
