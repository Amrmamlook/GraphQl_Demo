using GraphQl_Demo.Data;
using GraphQl_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQl_Demo.Services.Interface
{
    public interface ICategoryService
    {
        List<Category> GetCategories ();
        Category GetCategoryById (int id);
        Category AddGategory(Category category);
        void RemoveGategory(int id);
        Category UpdateCategory(int id,Category category);
        List<Category> GetAllCategoriesWithMenus();
    }
    public class CategoryService : ICategoryService
    {
        private readonly StoreContext db;

        public CategoryService(StoreContext _db)
        {
            this.db = _db;
        }

        public Category AddGategory(Category category)
        {
          db.Categories.Add(category);
            db.SaveChanges();
            return category;
        }

        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories.Where(x=>x.Id==id).FirstOrDefault();
        }

        public void RemoveGategory(int id)
        {
          var result=  db.Categories.Where(x => x.Id == id).FirstOrDefault();
            db.Categories.Remove(result);
            db.SaveChanges();
        }

        public Category UpdateCategory(int id, Category category)
        {
            var result = db.Categories.Where(x=>x.Id==id).FirstOrDefault();
            result!.Name= category.Name;
            db.SaveChanges();
            return category;
        }
        public List<Category> GetAllCategoriesWithMenus()
        {
            return db.Categories.Include(x => x.Menus).ToList();
        }
    }
}
