using Microsoft.OpenApi.Models;

namespace Products.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var openApi = new OpenApiInfo
            {
                Title = "Products API",
                Version = "v1",
                Description = "Products API 2024",
                TermsOfService = new Uri("https://opensource.org/licenses/NIT"),
                Contact = new OpenApiContact
                {
                    Name = "Tekton Labs",
                    Email = "info@tektonlabs.com",
                    Url = new Uri("https://www.tektonlabs.com/")
                },
                License = new OpenApiLicense
                {
                    Name = "Use under licence",
                    Url = new Uri("https://opensource.org/licenses/")
                }
            };

            services.AddSwaggerGen(x =>
            {
                openApi.Version = "v1";
                x.SwaggerDoc("v1", openApi);
            });

            return services;
        }
    }
}
