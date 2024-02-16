using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Productos.Application.Contracts.Persistense;
using Productos.Application.Contracts.Services;
using Productos.Application.Features.Products.Querys.GetProductById;
using Productos.Application.Mapping;
using Productos.Application.UnitTests.Moqs;
using Shouldly;

namespace Productos.Application.UnitTests.Products.Querys
{
    public class GetProductByIdTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IProductRepository> mockProductRepository;
        private readonly Mock<IDiscountApiService> mockDiscountApiService;
        private readonly MemoryCache cache;

        public GetProductByIdTest()
        {
            mockProductRepository = RepositoryMocks.GetProductConcreteRepository();
            mockDiscountApiService = new Mock<IDiscountApiService>();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            mapper = configurationProvider.CreateMapper();
            cache = new MemoryCache(new MemoryCacheOptions());
        }

        [Fact]
        public async Task Handle_ValidProduct_GetProductFromRepo()
        {
            var handler = new GetProductByIdQueryHandler(mapper, mockProductRepository.Object, mockDiscountApiService.Object, cache);
            var productId = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE");
            var result = await handler.Handle(new GetProductByIdQuery
            {
                ProductId = productId,
            }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ProductId.ShouldBe(productId);
        }

        [Fact]
        public async Task Handle_InValidProduct_GetProductFromRepo()
        {
            var handler = new GetProductByIdQueryHandler(mapper, mockProductRepository.Object, mockDiscountApiService.Object, cache);
            var productId = Guid.NewGuid();
            var result = await handler.Handle(new GetProductByIdQuery
            {
                ProductId = productId,
            }, CancellationToken.None);

            result.ShouldBeNull();
        }
    }
}
