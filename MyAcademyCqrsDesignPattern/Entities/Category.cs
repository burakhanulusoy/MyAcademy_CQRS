namespace MyAcademyCqrsDesignPattern.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; }//Ef core da ilşki için zorunldur bunu yapmak.


    }
}
