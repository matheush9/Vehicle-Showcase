using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleShowcase.Infrastructure.Data;

namespace VehicleShowcase.Infrastructure.Services.Extensions
{
    public static partial class DataServicesInitializerExtension
    {
        public static IServiceCollection RegisterDataServices(
          this IServiceCollection services, IConfiguration configuration)
        {
            RegisterDataContext(services, configuration);
            return services;
        }

        public static void RegisterDataContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("VehicleShowCaseConnectionString")));
        }
    }
}