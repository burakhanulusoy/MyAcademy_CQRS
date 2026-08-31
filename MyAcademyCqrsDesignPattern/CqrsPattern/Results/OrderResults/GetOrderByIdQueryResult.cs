namespace MyAcademyCqrsDesignPattern.CqrsPattern.Results.OrderResults;

public record GetOrderByIdQueryResult(int Id,
    string OrderResult,
    decimal Price,
    int CustomerId);
