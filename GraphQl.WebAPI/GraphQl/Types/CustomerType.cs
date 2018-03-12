using GraphQl.WebAPI.GraphQl.Models;

using GraphQL.Types;

namespace GraphQl.WebAPI.GraphQl.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(x => x.Id, true).Description("The Id of the Customer.");
            Field(x => x.Name, true).Description("The name of the Customer.");
        }
    }
}
