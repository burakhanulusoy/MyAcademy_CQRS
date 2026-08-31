namespace MyAcademyCqrsDesignPattern.CqrsPattern.Queries.CustomerQueries
{
    public class GetCustomerByIdWithOrdersQuery
    {
        public int Id { get; set; }

        public GetCustomerByIdWithOrdersQuery(int id)
        {
            Id = id;
        }
    }
}
