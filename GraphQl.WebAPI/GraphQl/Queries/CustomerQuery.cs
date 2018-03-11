using System.ComponentModel;

using GraphQl.WebAPI.GraphQl.Models;
using GraphQl.WebAPI.GraphQl.Types;

using GraphQL.Types;

namespace GraphQl.WebAPI.GraphQl.Queries
{
    public class CustomerQuery : ObjectGraphType
    {
        public CustomerQuery()
        {
            Field<CustomerType>("customer",
                arguments: new QueryArguments
                {
                    new QueryArgument<IntGraphType>{ Name = "id", Description = "the customers identifier"  },
                    new QueryArgument<StringGraphType>{Name = "name", Description = "the name of the customer"}
                },
                resolve: GetCustomer);
        }

        private Customer GetCustomer(ResolveFieldContext<object> context)
        {
            var id = context.GetArgument<int>("id");

            if (id != default(int))
            {
                return new Customer
                {
                    Name = "hej",
                    Id = id
                };
            }

            var name = context.GetArgument<string>("name");
            if (name != null)
            {
                return new Customer
                {
                    Name = name,
                    Id = 1
                };
            }

            throw new System.NotImplementedException();
        }
    }
}
