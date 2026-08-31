using MyAcademyCqrsDesignPattern.CqrsPattern.Results.OrderResults;
using MyAcademyCqrsDesignPattern.Entities;

namespace MyAcademyCqrsDesignPattern.CqrsPattern.Results.CustomerResults
{
    public class GetCustomersWithOrdersQueryResult
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public IList<GetOrdersByCustomerIdQueryResult> Orders { get; set; }
    }
}
