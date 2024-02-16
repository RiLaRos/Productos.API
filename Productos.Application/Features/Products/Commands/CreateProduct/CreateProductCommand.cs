using MediatR;

namespace Productos.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
