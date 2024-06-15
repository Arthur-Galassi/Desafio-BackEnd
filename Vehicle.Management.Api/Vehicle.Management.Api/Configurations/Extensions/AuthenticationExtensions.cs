using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Vehicle.Management.Api.Requests.Abstractions;
using static Vehicle.Management.Api.Configurations.Constants.AuthenticationConstants;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Vehicle.Management.Api.Configurations.Extensions
{
    internal class AuthenticationExtensions
    {
        internal static void AddAuthenticationServices(IServiceCollection services, IConfiguration configuration)
        {
            var secretKey = configuration[KeyMap.SecurityKey] ?? string.Empty;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    //ValidIssuer = "test",

                    ValidateAudience = false,
                    //ValidAudience = "test",

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var jwtToken = context.SecurityToken.GetType().Equals(typeof(JsonWebToken)) ? context.SecurityToken as JsonWebToken : null;
                        var userName = jwtToken!.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.Name)!.Value!;

                        // Obter o serviço RequestContextHolder e configurar o RequestUser
                        var requestContextHolder = context.HttpContext.RequestServices.GetRequiredService<IRequestContextHolder>();
                        requestContextHolder.RequestUser = userName;

                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}