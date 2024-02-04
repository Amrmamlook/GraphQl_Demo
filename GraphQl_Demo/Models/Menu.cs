namespace GraphQl_Demo.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
