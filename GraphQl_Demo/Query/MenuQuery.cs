using GraphQL;
using GraphQL.Types;
using GraphQl_Demo.Services.Interface;
using GraphQl_Demo.Types;
using Microsoft.AspNetCore.Mvc;

namespace GraphQl_Demo.Query
{
    public class MenuQuery:ObjectGraphType
    {
        public MenuQuery(IMenuService menuService)
        {
            Field<ListGraphType<MenuType>>("Menus").Resolve(x =>
            {
                return menuService.GetAllMenus();
            });
            Field<MenuType>("Menu").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name= "menuId"}))
            .Resolve(x =>
            {
                return menuService.GetMenuById(x.GetArgument<int>("menuId"));
            });
        }
    }
}
