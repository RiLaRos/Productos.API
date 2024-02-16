using Microsoft.Extensions.DependencyInjection;
using Productos.Application.Contracts.Persistense;
using Productos.Data.Repositories;

namespace Productos.Data
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, InMemoryProductRepository>();
            return services;
        }
    }
}
