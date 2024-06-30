using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApplicationService.Application.Interfaces;
using ApplicationService.Infrastructure.Persistence;

namespace ApplicationService.Infrastructure
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<IRepository, Repository>();

            return services;
        }
        public static IServiceCollection ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options =>
            {
                if (connectionString != null)
                    options.UseNpgsql(connectionString);
            });

            return services;
        }
    }
}