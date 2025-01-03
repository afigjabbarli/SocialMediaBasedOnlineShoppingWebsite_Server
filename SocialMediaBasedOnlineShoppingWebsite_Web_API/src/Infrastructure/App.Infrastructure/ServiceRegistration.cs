using App.Application.Interfaces.Services;
using App.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IConfigurationAccessor, ConfigurationAccessor>();

            return services; 
        }
    }
}
