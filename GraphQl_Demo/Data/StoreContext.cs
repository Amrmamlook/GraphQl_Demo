using GraphQl_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQl_Demo.Data
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {
                
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Menu>().HasData
            (

            new Menu() { Id = 1, Name = "Classic Burger", Description = "A juicy chicken burger with lettuce and cheese", Price = 8.99,CategoryId=4 },
            new Menu() { Id = 2, Name = "Margherita Pizza", Description = "Tomato, mozzarella, and basil pizza", Price = 10.50,CategoryId=5 },
            new Menu() { Id = 3, Name = "Grilled Chicken Salad", Description = "Fresh garden salad with grilled chicken", Price = 7.95,CategoryId=2 },
            new Menu() { Id = 4, Name = "Pasta Alfredo", Description = "Creamy Alfredo sauce with fettuccine pasta", Price = 12.75,CategoryId=6 },
            new Menu() { Id = 5, Name = "Chocolate Brownie Sundae", Description = "Warm chocolate brownie with ice cream and fudge", Price = 6.99,CategoryId=3 }

            );
            modelBuilder.Entity<Category>().HasData
                (
                new Category() { Id = 1,Name="Appetizer" },
                new Category() { Id = 2,Name="Main" },
                new Category() { Id = 3,Name="Drinks" },
                new Category() { Id = 4,Name="Burger" },
                new Category() { Id = 5,Name="Pizza" },
                new Category() { Id = 6,Name="Pasta" }
                );
        }
    }
}
