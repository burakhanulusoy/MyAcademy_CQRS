namespace MyAcademyCqrsDesignPattern.CqrsPattern.Queries.OrderQueries;

public class GetOrderByIdQuery
{
    public int Id { get; set; }

    public GetOrderByIdQuery(int id)
    {
        Id = id ;
    }
}
