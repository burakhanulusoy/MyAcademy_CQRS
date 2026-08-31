namespace MyAcademyCqrsDesignPattern.CqrsPattern.Commands.OrderCommands
{
    public class RemoveOrderCommand
    {
        public int Id { get; set; }

        public RemoveOrderCommand(int id)
        {
            Id = id;
        }
    }
}
