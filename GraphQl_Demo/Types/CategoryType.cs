using GraphQL.Types;
using GraphQl_Demo.Models;
using GraphQl_Demo.Services.Interface;
using System.ComponentModel.Design;

namespace GraphQl_Demo.Types
{
    public class CategoryType:ObjectGraphType<Category>
    {
        public CategoryType(IMenuService service)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field<ListGraphType<MenuType>>("Menus").Resolve(x =>
            {
                var category = x.Source;
                return service.GetMenusByCategoryId(category.Id);
            });
        }
    }
}
