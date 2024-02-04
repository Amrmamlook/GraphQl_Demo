namespace GraphQl_Demo.Models
{
    public class Category
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<Menu> Menus { get; set;}
    }
}
