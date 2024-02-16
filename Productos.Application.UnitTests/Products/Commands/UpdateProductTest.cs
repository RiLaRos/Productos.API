using AutoMapper;
using Moq;
using Productos.Application.Contracts.Persistense;
using Productos.Application.Features.Products.Commands.UpdateProduct;
using Productos.Application.Mapping;
using Productos.Application.UnitTests.Moqs;
using Shouldly;

namespace Productos.Application.UnitTests.Products.Commands
{
    public class UpdateProductTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IProductRepository> mockProductRepository;

        public UpdateProductTest()
        {
            mockProductRepository = RepositoryMocks.GetProductConcreteRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidProduct_UpdateInProductRepo()
        {
            var handler = new UpdateProductCommandHandler(mapper, mockProductRepository.Object);
            var productId = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE");

            var command = new UpdateProductCommand
            {
                ProductId = productId,
                Name = "Producto 2",
                Description = "Descripcion 2",
                Price = 200,
                Stock = 20,
                Status = Domain.Enums.ProductStatus.Inactive
            };

            await handler.Handle(command, CancellationToken.None);

            var allProducts = mockProductRepository.Object.Find(productId);
            allProducts.Name.ShouldBe(command.Name);
        }
    }
}
