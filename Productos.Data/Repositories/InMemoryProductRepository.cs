using Productos.Application.Contracts.Persistense;
using Productos.Domain.Entities;
using Productos.Domain.Enums;

namespace Productos.Data.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> products;

        public InMemoryProductRepository()
        {
            products =
            [
                new Product { ProductId = Guid.Parse("5AF08FF9-9CA5-497E-A9D9-562668AD00CE"), Name = "Product 1", Description = "Description 1", Price = 100, Stock = 10, Status = ProductStatus.Active },
                new Product { ProductId = Guid.Parse("61DD5EB4-09DF-4480-835B-78E7B1FE4BD8"), Name = "Product 2", Description = "Description 2", Price = 200, Stock = 20, Status = ProductStatus.Active },
            ];
        }

        public List<Product> ListAll()
        {
            return products;
        }

        public Product Add(Product entity)
        {
            products.Add(entity);
            return entity;
        }

        public Product Find(Guid id)
        {
            return products.Find(p => p.ProductId == id);
        }

        public bool Update(Product entity)
        {
            var product = products.Find(p => p.ProductId == entity.ProductId);
            product.Name = entity.Name;
            product.Description = entity.Description;
            product.Price = entity.Price;
            product.Stock = entity.Stock;
            product.Status = entity.Status;
            return true;
        }
    }
}
