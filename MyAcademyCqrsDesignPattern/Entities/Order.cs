namespace MyAcademyCqrsDesignPattern.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string OrderResult { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
