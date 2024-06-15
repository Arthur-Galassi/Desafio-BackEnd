using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using static Vehicle.Management.Api.Configurations.Constants.AuthenticationConstants;
using Microsoft.AspNetCore.Authorization;

namespace Vehicle.Management.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Authorize]
    public class BypassLoginController(IConfiguration configuration) : ControllerBase
    {
        [HttpPost("DummyAdminBearerToken")]
        [AllowAnonymous]
        public IActionResult LoginAdmin([FromBody] UserRequest userName) =>  
        Ok(new JwtSecurityTokenHandler().WriteToken(
            new JwtSecurityToken(
                "test",
                "test",
                [
                    new(ClaimTypes.Name, userName.UserName),
                    new(ClaimTypes.Role, "Admin")
                ],
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[KeyMap.SecurityKey]!)),
                SecurityAlgorithms.HmacSha256)
            ))
        );
    }

    public class UserRequest
    {
        public string UserName { get; set; } = default!;
    }
}