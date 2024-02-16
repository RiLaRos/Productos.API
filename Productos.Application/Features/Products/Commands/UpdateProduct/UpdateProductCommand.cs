using MediatR;
using Productos.Domain.Enums;

namespace Productos.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public ProductStatus Status { get; set; }

        public int Stock { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }
    }
}
