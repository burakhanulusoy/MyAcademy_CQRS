namespace MyAcademyCqrsDesignPattern.CqrsPattern.Commands.OrderCommands;

public record CreateOrderCommand(
    string OrderResult,
    decimal Price,
    int CustomerId);