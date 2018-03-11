using System.Threading.Tasks;

using GraphQl.WebAPI.GraphQl;
using GraphQl.WebAPI.GraphQl.Queries;

using GraphQL;
using GraphQL.Types;

using Microsoft.AspNetCore.Mvc;

namespace GraphQl.WebAPI.Controllers
{
    [Route("graphql")]
    public class CustomerController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            var schema = new Schema { Query = new CustomerQuery() };

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