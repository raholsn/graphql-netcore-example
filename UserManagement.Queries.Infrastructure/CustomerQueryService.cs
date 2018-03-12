using UserManagement.Queries.Application;
using UserManagement.Queries.Application.dto;

namespace UserManagement.Queries.Infrastructure
{
    public class CustomerQueryService : ICustomerQueryService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerQueryService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerDto GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public CustomerDto GetCustomerByName(string name)
        {
            return _customerRepository.GetByName(name);
        }
    }
}
