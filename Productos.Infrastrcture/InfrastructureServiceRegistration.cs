using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Productos.Application.Contracts.Services;
using Productos.Infrastructure.DiscountApi;

namespace Productos.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DiscountApiSettings>(configuration.GetSection("DiscountApiSettings"));
            services.AddHttpClient<IDiscountApiService, DiscountApiService>();
            services.AddSingleton<IDiscountApiService, DiscountApiService>();
            return services;
        }
    }
}
