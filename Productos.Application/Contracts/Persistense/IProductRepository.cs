using Productos.Domain.Entities;

namespace Productos.Application.Contracts.Persistense
{
    public interface IProductRepository
    {
        List<Product> ListAll();
        Product Find(Guid id);
        Product Add(Product entity);
        bool Update(Product entity);
    }
}
