namespace Vehicle.Management.Api.Configurations.Extensions
{
    internal class AuthorizationExtensions
    {
        internal static void AddAuthorizationServices(IServiceCollection services)
        {
            services.AddAuthorizationBuilder()
                .AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
        }
    }
}