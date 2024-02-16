using AutoMapper;
using MediatR;
using Productos.Application.Contracts.Persistense;
using Productos.Domain.Entities;
using Productos.Domain.Enums;

namespace Productos.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public CreateProductCommandHandler(
            IMapper mapper,
            IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);
            product.Status = ProductStatus.Active;

            var response = productRepository.Add(product);
            return response != null;
        }
    }
}
