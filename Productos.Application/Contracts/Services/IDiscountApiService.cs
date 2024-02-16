namespace Productos.Application.Contracts.Services
{
    public interface IDiscountApiService
    {
        Task<decimal> GetDiscount(Guid productId);
    }
}
