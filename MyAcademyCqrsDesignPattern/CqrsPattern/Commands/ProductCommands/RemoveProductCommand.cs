namespace MyAcademyCqrsDesignPattern.CqrsPattern.Commands.ProductCommands
{
    public class RemoveProductCommand
    {
        public int Id { get; set; }

        public RemoveProductCommand(int id)
        {
            Id = id;
        }
    }
}
