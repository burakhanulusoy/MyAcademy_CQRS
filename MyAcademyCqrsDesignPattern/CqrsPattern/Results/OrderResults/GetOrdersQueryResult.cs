using MyAcademyCqrsDesignPattern.CqrsPattern.Results.CustomerResults;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Results.OrderResults;

public class GetOrdersQueryResult
{
    public int Id { get; set; }
    public string OrderResult { get; set; }
    public decimal Price { get; set; }
    public int CustomerId { get; set; }
    public GetCustomersQueryResult Customer { get; set; }
}