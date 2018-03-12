using System;

using GraphQL.Types;

using UserManagement.WebAPI.GraphQl.Queries;

namespace UserManagement.WebAPI.GraphQl.Schema
{
    public class CustomerSchema : GraphQL.Types.Schema
    {
        public CustomerSchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (CustomerQuery)resolveType(typeof(CustomerQuery));
        }
    }
}
