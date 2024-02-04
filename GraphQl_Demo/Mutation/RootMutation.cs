using GraphQL.Types;

namespace GraphQl_Demo.Mutation
{
    public class RootMutation:ObjectGraphType
    {
        public RootMutation()
        {
            Field<MenuMutation>("menuMutation").Resolve(context => new { });
            Field<CategoryMutation>("CategoryMutation").Resolve(context => new { });
        }
    }
}
