using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vehicle.Management.Api.Requests.Motorcycle;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Vehicle.Management.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MotorcycleController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(1000);
            return Ok("");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MotorcyclePostRequest request)
        {
            await Task.Delay(1000);
            return Ok("");
        }

        [HttpPatch]
        public async Task<IActionResult> Patch()
        {
            await Task.Delay(1000);
            return Ok("");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await Task.Delay(1000);
            return Ok("");
        }
    }
}