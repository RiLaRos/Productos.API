using AutoMapper;
using MediatR;
using Productos.Application.Contracts.Persistense;
using Productos.Domain.Entities;

namespace Productos.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public UpdateProductCommandHandler(
            IMapper mapper,
            IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);
            productRepository.Update(product);
            return true;
        }
    }
}
