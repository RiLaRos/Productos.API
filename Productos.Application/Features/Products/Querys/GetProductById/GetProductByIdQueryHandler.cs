using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Productos.Application.Contracts.Persistense;
using Productos.Application.Contracts.Services;

namespace Productos.Application.Features.Products.Querys.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdVm>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;
        private readonly IDiscountApiService discountApiService;
        private readonly IMemoryCache cache;

        public GetProductByIdQueryHandler(
            IMapper mapper,
            IProductRepository productRepository,
            IDiscountApiService discountApiService,
            IMemoryCache cache)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
            this.discountApiService = discountApiService;
            this.cache = cache;
        }

        public async Task<GetProductByIdVm> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = productRepository.Find(request.ProductId);

            if (product != null)
            {

                if (!cache.TryGetValue($"StatusCache_{product.Status}", out string statusName))
                {
                    statusName = product.Status.ToString();
                    cache.Set($"StatusCache_{product.Status}", statusName, TimeSpan.FromMinutes(5));
                }

                var response = mapper.Map<GetProductByIdVm>(product);
                response.StatusName = statusName;
                response.Discount = await discountApiService.GetDiscount(product.ProductId);

                return response;
            }
            else
            {
                return null;
            }
        }
    }
}
