using System;

using GraphQL.Types;

using Microsoft.Extensions.DependencyInjection;

using UserManagement.Queries.Application;
using UserManagement.WebAPI.GraphQl.Models;
using UserManagement.WebAPI.GraphQl.Types;

namespace UserManagement.WebAPI.GraphQl.Queries
{
    public class CustomerQuery : ObjectGraphType
    {
        public CustomerQuery(IServiceProvider serviceProvider)
        {
            Field<CustomerType>("customer",
                arguments: new QueryArguments
                {
                    new QueryArgument<IntGraphType> { Name = "id", Description = "the customers identifier" },
                    new QueryArgument<StringGraphType> { Name = "name", Description = "the name of the customer" },
                },
                resolve: context => GetCustomer(context, serviceProvider));
            Field<AccountType>("account",
                arguments: new QueryArguments
                {
                    new QueryArgument<IntGraphType> { Name = "id", Description = "the customers identifier" },
                    new QueryArgument<StringGraphType> { Name = "currency", Description = "the currency" }
                },
                resolve: context => GetAccount(context,serviceProvider));
        }

        private Customer GetCustomer(ResolveFieldContext<object> context, IServiceProvider serviceProvider)
        {
            var service = serviceProvider.GetService<ICustomerQueryService>();

            var id = context.GetArgument<int?>("id");

            if (id != null)
            {
                var response = service.GetCustomerById((int)id );

                return new Customer
                {
                    Name = response.Name,
                    Id = response.Id
                };
            }

            var name = context.GetArgument<string>("name");
            if (name != null)
            {
                var response = service.GetCustomerByName(name);

                return new Customer
                {
                    Name = response.Name,
                    Id = response.Id
                };
            }

            return null;
        }

        private Account GetAccount(ResolveFieldContext<object> context, IServiceProvider serviceProvider)
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


    }
}
