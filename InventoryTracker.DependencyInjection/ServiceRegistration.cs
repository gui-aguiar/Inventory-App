using InventoryTracker.Contracts;
using InventoryTracker.Interfaces;
using InventoryTracker.Repositories;
using InventoryTracker.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryTracker.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {   
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IComputerService, ComputerService>();
            services.AddScoped<IComputerStatusService, ComputerStatusService>();
            services.AddScoped<IComputerUserService, ComputerUserService>();
            return services;
        }
    }
}
