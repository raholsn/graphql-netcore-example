using GraphQL.Types;

using UserManagement.WebAPI.GraphQl.Models;

namespace UserManagement.WebAPI.GraphQl.Types
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType()
        {
            Field(x => x.Id, true).Description("The Id of the account.");
            Field(x => x.Balance, true).Description("The balance.");
            Field(x => x.Currency, true).Description("The currency.");
        }
    }
}
