using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Productos.Application.Contracts.Services;

namespace Productos.Infrastructure.DiscountApi
{
    public class DiscountApiService : IDiscountApiService
    {
        private readonly DiscountApiSettings discountApiOptions;
        private readonly IHttpClientFactory httpClientFactory;

        public DiscountApiService(
            IOptions<DiscountApiSettings> settings,
            IHttpClientFactory httpClientFactory)
        {
            this.discountApiOptions = settings.Value;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<decimal> GetDiscount(Guid productId)
        {
            var apiUrl = $"{discountApiOptions.BaseUrl}/discounts/{productId}";
            var client = httpClientFactory.CreateClient();
            try
            {
                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var productDiscount = JsonConvert.DeserializeObject<ProductDiscount>(responseContent);
                    return productDiscount.Discount;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al llamar a la API de descuentos: {ex.Message}", ex);
            }
        }
    }
}
