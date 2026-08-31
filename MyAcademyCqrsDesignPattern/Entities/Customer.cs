namespace MyAcademyCqrsDesignPattern.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public IList<Order> Orders { get; set; }

    }
}
