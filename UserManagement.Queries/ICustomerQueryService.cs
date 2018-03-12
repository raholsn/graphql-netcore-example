using UserManagement.Queries.Application.dto;

namespace UserManagement.Queries.Application
{
    public interface ICustomerQueryService
    {
        CustomerDto GetCustomerById(int id);
        CustomerDto GetCustomerByName(string name);
    }
}
