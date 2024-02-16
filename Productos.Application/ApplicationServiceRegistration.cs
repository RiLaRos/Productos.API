using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Productos.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddMemoryCache();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
