using MediatR;

namespace Productos.Application.Features.Products.Querys.GetProductById
{
    public class GetProductByIdQuery : IRequest<GetProductByIdVm>
    {
        public Guid ProductId { get; set; }
    }
}
