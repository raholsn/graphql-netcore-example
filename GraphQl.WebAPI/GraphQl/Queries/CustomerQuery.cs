using GraphQl.WebAPI.GraphQl.Models;
using GraphQl.WebAPI.GraphQl.Types;

using GraphQL.Types;

namespace GraphQl.WebAPI.GraphQl.Queries
{
    public class CustomerQuery : ObjectGraphType
    {
        public CustomerQuery()
        {
            Field<CustomerType>("customer", resolve: context => new Customer { Id = 1, Name = "R2-D2" });
        }
    }
}
