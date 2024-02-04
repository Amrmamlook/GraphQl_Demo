using GraphQL.Types;

namespace GraphQl_Demo.Query
{
    public class RootQuery:ObjectGraphType
    {
        public RootQuery()
        {
            Field<MenuQuery>("MenuQuery").Resolve(context => new { });
            Field<CategoryQuery>("CategoryQuery").Resolve(context => new { });
        }
    }
}
