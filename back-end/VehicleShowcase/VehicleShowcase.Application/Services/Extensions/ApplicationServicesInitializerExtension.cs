using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VehicleShowcase.Application.Interfaces;

namespace VehicleShowcase.Application.Services.Extensions
{
    public static partial class ApplicationServicesInitializerExtension
    {
        public static IServiceCollection RegisterApplicationServices(
                                    this IServiceCollection services)
        {
            RegisterCustomServices(services);
            RegisterMapper(services);

            return services;
        }

        public static void RegisterCustomServices(IServiceCollection services)
        {
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IVehicleService, VehicleService>();
        }

        public static void RegisterMapper(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
