namespace MyAcademyCqrsDesignPattern.CqrsPattern.Commands.OrderCommands;

public record UpdateOrderCommand(int Id,
    string OrderResult,
    decimal Price,
    int CustomerId);
