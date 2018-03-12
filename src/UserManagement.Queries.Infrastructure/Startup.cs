
using Microsoft.Extensions.DependencyInjection;

using UserManagement.Queries.Application;

namespace UserManagement.Queries.Infrastructure
{
    public static class Startup
    {
        public static void Initilize(IServiceCollection services)
        {
            services.AddTransient<ICustomerQueryService, CustomerQueryService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
