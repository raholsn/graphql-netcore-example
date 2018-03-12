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
                    new QueryArgument<IntGraphType> { Name = "id", Description = "the customers identifier" },
                    new QueryArgument<StringGraphType> { Name = "name", Description = "the name of the customer" }
                },
                resolve: GetCustomer);
            Field<AccountType>("account",
                arguments: new QueryArguments
                {
                    new QueryArgument<IntGraphType> { Name = "id", Description = "the customers identifier" },
                    new QueryArgument<StringGraphType> { Name = "currency", Description = "the currency" }
                },
                resolve: GetAccount);
        }

        private Account GetAccount(ResolveFieldContext<object> context)
        {
            var id = context.GetArgument<int?>("id");

            if (id != null)
            {
                return new Account
                {
                    Currency = "USD",
                    Balance = 1000.0,
                    Id = id
                };
            }

            var currency = context.GetArgument<string>("currency");

            if (currency != null)
            {
                return new Account
                {
                    Currency = "Sek",
                    Balance = 1000.0,
                    Id = 1
                };
            }

            return null;
        }

        private Customer GetCustomer(ResolveFieldContext<object> context)
        {
            var id = context.GetArgument<int?>("id");

            if (id != null)
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

            return null;
        }
    }
}
