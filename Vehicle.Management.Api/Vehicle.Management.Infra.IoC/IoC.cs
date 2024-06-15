using Microsoft.Extensions.DependencyInjection;

namespace Vehicle.Management.Infra.IoC
{
    public static class IoC
    {
        public static IServiceCollection ConfigureContainer(this IServiceCollection service)
        {
            return service;
        }
    }
}