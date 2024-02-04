using GraphQl_Demo.Mutation;
using GraphQl_Demo.Query;

namespace GraphQl_Demo.Schema
{
    public class RootSchema:GraphQL.Types.Schema
    {
        public RootSchema(IServiceProvider service):base(service)
        {
            Query = service.GetRequiredService<RootQuery>();
            //Mutation = service.GetRequiredService<RootMutation>();
        }
    }
}
