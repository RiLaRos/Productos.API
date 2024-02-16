using Moq;
using Productos.Application.Contracts.Persistense;
using Productos.Domain.Entities;

namespace Productos.Application.UnitTests.Moqs
{
    public class RepositoryMocks
    {
        public static Mock<IProductRepository> GetProductConcreteRepository()
        {
            var products = new List<Product>
            {
                new Product
                {
                    ProductId = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"),
                    Name = "Producto 1",
                    Description = "Descripcion 1",
                    Price = 100,
                    Stock = 10,
                    Status = Domain.Enums.ProductStatus.Active
                }
            };

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(repo => repo.ListAll()).Returns(products);
            mockProductRepository.Setup(repo => repo.Find(It.IsAny<Guid>())).Returns(
                (Guid id) =>
                {
                    var product = products.FirstOrDefault(p => p.ProductId == id);
                    return product;
                }
                );

            mockProductRepository.Setup(repo => repo.Add(It.IsAny<Product>())).Returns(
                (Product product) =>
                {
                    products.Add(product);
                    return product;
                });

            mockProductRepository.Setup(repo => repo.Update(It.IsAny<Product>())).Returns(
                (Product product) =>
                {
                    var index = products.FindIndex(p => p.ProductId == product.ProductId);
                    if (index >= 0)
                    {
                        products[index] = product;
                    }
                    return true;
                });

            return mockProductRepository;
        }
    }
}
