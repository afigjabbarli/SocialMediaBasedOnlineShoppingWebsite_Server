using App.Application.Interfaces.Services;
using App.Persistence.Contexts.Read;
using App.Persistence.Contexts.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<WriteDbContext>(options =>
            {
                var configurationAccessor = services.BuildServiceProvider().GetRequiredService<IConfigurationAccessor>();
                var writeDbCredentials = configurationAccessor.GetConnectionString("Development", "WriteDbCredentials");
                options.UseNpgsql(writeDbCredentials);
            });

            services.AddDbContext<ReadDbContext>(options =>
            {
                var configurationAccessor = services.BuildServiceProvider().GetRequiredService<IConfigurationAccessor>();
                var readDbCredentials = configurationAccessor.GetConnectionString("Development", "ReadDbCredentials");
                options.UseNpgsql(readDbCredentials);
            });

            return services;
        }
    }
}
