using AutoMapper;
using Moq;
using Productos.Application.Contracts.Persistense;
using Productos.Application.Features.Products.Commands.CreateProduct;
using Productos.Application.Mapping;
using Productos.Application.UnitTests.Moqs;
using Shouldly;

namespace Productos.Application.UnitTests.Products.Commands
{
    public class CreateProductTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IProductRepository> mockProductRepository;

        public CreateProductTest()
        {
            mockProductRepository = RepositoryMocks.GetProductConcreteRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidProduct_AddedToProductRepo()
        {
            var handler = new CreateProductCommandHandler(mapper, mockProductRepository.Object);

            await handler.Handle(new CreateProductCommand
            {
                ProductId = Guid.NewGuid(),
                Name = "Producto 2",
                Description = "Descripcion 2",
                Price = 200,
                Stock = 20
            }, CancellationToken.None);

            var allProducts = mockProductRepository.Object.ListAll();
            allProducts.Count.ShouldBe(2);
        }
    }
}
