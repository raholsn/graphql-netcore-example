using UserManagement.Queries.Application;
using UserManagement.Queries.Application.dto;

namespace UserManagement.Queries.Infrastructure
{
    public class CustomerQueryService : ICustomerQueryService
    {
        public CustomerDto GetCustomerById(int id)
        {
            return new CustomerDto { Name = "byid", Id = 1 };
        }

        public CustomerDto GetCustomerByName(string name)
        {
            return new CustomerDto { Name = "byname", Id = 1 };
        }
    }
}
