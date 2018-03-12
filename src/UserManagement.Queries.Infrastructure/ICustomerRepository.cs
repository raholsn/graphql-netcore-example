using UserManagement.Queries.Application.dto;

namespace UserManagement.Queries.Infrastructure
{
    public interface ICustomerRepository
    {
        CustomerDto GetById(int id);

        CustomerDto GetByName(string name);
    }
}
