using System;
using System.Threading.Tasks;

using GraphQL;
using GraphQL.Types;

using Microsoft.AspNetCore.Mvc;

using UserManagement.WebAPI.GraphQl;
using UserManagement.WebAPI.GraphQl.Queries;

namespace UserManagement.WebAPI.Controllers
{
    [Route("graphql")]
    public class GraphQlController : Controller
    {
        private readonly IServiceProvider serviceProvider;
        public GraphQlController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            var schema = new Schema { Query = new CustomerQuery(serviceProvider) };

            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = schema;
                x.Query = query.Query;
                x.Inputs = query.Variables;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
