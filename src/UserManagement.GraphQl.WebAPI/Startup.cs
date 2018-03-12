using GraphQL.Types;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using UserManagement.Queries.Application;
using UserManagement.Queries.Infrastructure;
using UserManagement.WebAPI.GraphQl.Queries;
using UserManagement.WebAPI.GraphQl.Schema;

namespace UserManagement.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddTransient<ICustomerQueryService,CustomerQueryService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            //services.AddTransient<CustomerQuery>();
            var sp = services.BuildServiceProvider();
            //services.AddTransient<ISchema>(_ => new CustomerSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<CustomerQuery>() });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseGraphiQl();
        }
    }
}
