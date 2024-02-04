using GraphQl_Demo.Data;
using GraphQl_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQl_Demo.Services.Interface
{
    public interface IMenuService
    {
       List<Menu> GetAllMenus();
        Menu GetMenuById(int id);
        Menu AddMenu(Menu menu);
        Menu UpdateMenu(int id,Menu menu);
        void DeleteMenu(int id);
        List<Menu> GetMenusByCategoryId(int categoryId);
    }
    public class MenuService : IMenuService
    {
        private readonly StoreContext db;

        public MenuService(StoreContext _db)
        {
            this.db = _db;
        }
        Menu IMenuService.AddMenu(Menu menu)
        {
            db.Menus.Add(menu);
            db.SaveChanges();
            return menu;
        }

        void IMenuService.DeleteMenu(int id)
        {
            var result = db.Menus.Where(x => x.Id == id).FirstOrDefault();
            db.Menus.Remove(result);
            db.SaveChanges();
        }

        List<Menu> IMenuService.GetAllMenus()
        {
            return db.Menus.ToList();  
        }

        Menu IMenuService.GetMenuById(int id)
        {
            return db.Menus.Where(x => x.Id == id).FirstOrDefault();
        }

        Menu IMenuService.UpdateMenu(int id, Menu menu)
        {
            var menuResult = db.Menus.Find(id);
            menuResult.Name =menu.Name;
            menuResult.Price = menu.Price;
            menuResult.Description = menu.Description;
            db.SaveChanges(); return menuResult;
        }
        public List<Menu> GetMenusByCategoryId(int categoryId)
        {
            return db.Menus
                .Where(menu => menu.CategoryId == categoryId)
                .ToList();
        }

    }
}
