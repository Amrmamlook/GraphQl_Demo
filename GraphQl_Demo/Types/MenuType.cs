using GraphQL.Types;
using GraphQl_Demo.Models;

namespace GraphQl_Demo.Types
{
    public class MenuType:ObjectGraphType<Menu>
    {
        public MenuType()
        {
            Field(x => x.Id);
            Field(x=>x.Name);
            Field(x=>x.Description);
            Field(x => x.Price);
            Field(x => x.CategoryId);
        }
    }
}
