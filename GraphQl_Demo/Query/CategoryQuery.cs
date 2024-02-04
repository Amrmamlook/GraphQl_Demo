using GraphQL;
using GraphQL.Types;
using GraphQl_Demo.Services.Interface;
using GraphQl_Demo.Types;

namespace GraphQl_Demo.Query
{
    public class CategoryQuery:ObjectGraphType
    {
        public CategoryQuery(ICategoryService categoryService)
        {
            Field<CategoryType>("category").Arguments(new QueryArguments(new QueryArgument<IntGraphType>() { Name = "categoryId" }))
            .Resolve(x =>
            {
                return categoryService.GetCategoryById(x.GetArgument<int>("categoryId"));
            });


            Field<ListGraphType<CategoryType>>("categories").Resolve(x =>
            {
                return categoryService.GetCategories();
            });

            Field<ListGraphType<CategoryType>>("CategoryWithMenus").Resolve(x =>
            {
                return categoryService.GetAllCategoriesWithMenus();
            });
        }
    }
}
