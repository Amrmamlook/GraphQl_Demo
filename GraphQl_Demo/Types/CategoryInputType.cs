using GraphQL.Types;

namespace GraphQl_Demo.Types
{
    public class CategoryInputType:InputObjectGraphType
    {
        public CategoryInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
        }
    }
}
