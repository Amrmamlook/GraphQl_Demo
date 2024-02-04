using GraphQL;
using GraphQL.Types;
using GraphQl_Demo.Models;
using GraphQl_Demo.Services.Interface;
using GraphQl_Demo.Types;

namespace GraphQl_Demo.Mutation
{
    public  class MenuMutation:ObjectGraphType
    {
        public MenuMutation(IMenuService menuService)
        {
            Field<MenuType>("CreateMenu").Arguments(new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu" }))
                 .Resolve(x =>
                 {
                     return menuService.AddMenu(x.GetArgument<Menu>("menu"));
                 });

            Field<StringGraphType>("DeleteMenu").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }))
                .Resolve(x =>
                {
                    var menuId = x.GetArgument<int>("menuId");
                    menuService.DeleteMenu(menuId);
                    return $"The Menu With Id {menuId} Has Been Deleted";
                });

            Field<MenuType>("UpdateMenu").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name= "menuId" },
                new QueryArgument<MenuInputType> { Name="menu"})).Resolve(x=>
                {
                    var menu = x.GetArgument<Menu>("menu");
                    var menuId = x.GetArgument<int>("menuId");
                    return menuService.UpdateMenu(menuId, menu);
                });


        }
    }
}
