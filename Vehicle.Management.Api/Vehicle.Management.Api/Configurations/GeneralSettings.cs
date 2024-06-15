using Vehicle.Management.Api.Configurations.Extensions;

namespace Vehicle.Management.Api.Configurations
{
    public static class GeneralSettings
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection service, IConfiguration configuration)
        {
            AuthenticationExtensions.AddAuthenticationServices(service, configuration);
            AuthorizationExtensions.AddAuthorizationServices(service);
            SwaggerExtensions.Configure(service);

            return service;
        }
    }
}