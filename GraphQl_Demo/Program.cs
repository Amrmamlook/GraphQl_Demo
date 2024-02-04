using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQl_Demo.Data;
using GraphQl_Demo.Mutation;
using GraphQl_Demo.Query;
using GraphQl_Demo.Schema;
using GraphQl_Demo.Services.Interface;
using GraphQl_Demo.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQl_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<StoreContext>(x=>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("Sql"));
            });


            builder.Services.AddScoped<IMenuService, MenuService>();
            builder.Services.AddScoped<ICategoryService,CategoryService>();

            builder.Services.AddTransient<MenuType>();
            builder.Services.AddTransient<CategoryType>();
            builder.Services.AddTransient<CategoryInputType>();
            builder.Services.AddTransient<MenuInputType>();


            builder.Services.AddTransient<RootSchema>();

            builder.Services.AddTransient<RootQuery>();
            builder.Services.AddTransient<CategoryQuery>();
            builder.Services.AddTransient<MenuQuery>();


            builder.Services.AddTransient<RootMutation>();
            builder.Services.AddTransient<MenuMutation>();
            builder.Services.AddTransient<CategoryMutation>();

            builder.Services.AddTransient<ISchema,RootSchema>();

            builder.Services.AddGraphQL(x => x.AddAutoSchema<ISchema>().AddSystemTextJson());
            // Add services to the container.
            builder.Services.AddAuthorization();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();
           

            app.Run();
        }
    }
}
