using System;

using UserManagement.Queries.Application.dto;

namespace UserManagement.Queries.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerDto GetById(int id)
        {
            return new CustomerDto{Name = "byid",Id = 1};
        }

        public CustomerDto GetByName(string name)
        {
            return new CustomerDto{Name = "byname",Id = 1};
        }
    }
}
