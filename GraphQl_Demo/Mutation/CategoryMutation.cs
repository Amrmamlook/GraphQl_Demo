using GraphQL;
using GraphQL.Types;
using GraphQl_Demo.Models;
using GraphQl_Demo.Services.Interface;
using GraphQl_Demo.Types;

namespace GraphQl_Demo.Mutation
{
   
    
        public class CategoryMutation:ObjectGraphType
        {
            public CategoryMutation(ICategoryService categoryService)
            {
                Field<CategoryType>("CreateCategory").Arguments(new QueryArguments(new QueryArgument<CategoryInputType> { Name = "category" }))
                .Resolve(x =>
                {
                    var category = x.GetArgument<Category>("category");
                    return categoryService.AddGategory(category);
                });


                Field<CategoryType>("UpdateCategory").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" },
                  new QueryArgument<CategoryInputType> { Name="category"})) 
                    .Resolve(x =>
                    {
                        var category = x.GetArgument<Category>("category");
                        var categoryId = x.GetArgument<int>("categoryId");
                        return categoryService.UpdateCategory(categoryId, category);
                    });

                Field<StringGraphType>("DeleteCategory").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" }))
                    .Resolve(x =>
                    {
                        var categoryId = x.GetArgument<int>("categoryId");
                        categoryService.RemoveGategory(categoryId);

                        return $"The Category With Id {categoryId} Has Been Deleted !";
                    });
            }
        }
    }

