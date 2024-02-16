using MediatR;
using Microsoft.AspNetCore.Mvc;
using Productos.Application.Features.Products.Commands.CreateProduct;
using Productos.Application.Features.Products.Commands.UpdateProduct;
using Productos.Application.Features.Products.Querys.GetProductById;
using Products.API.Dtos;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductByIdVm>> Get(Guid id)
        {
            var response = await mediator.Send(new GetProductByIdQuery { ProductId = id });
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveProductRequest request)
        {
            var response = await mediator.Send(new CreateProductCommand
            {
                ProductId = request.Id,
                Name = request.Name,
                Stock = request.Stock,
                Description = request.Description,
                Price = request.Price,
            });

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProductRequest request)
        {
            var product = await mediator.Send(new GetProductByIdQuery { ProductId = id });
            if (product == null)
            {
                return NotFound();
            }

            var response = await mediator.Send(new UpdateProductCommand
            {
                ProductId = id,
                Description = request.Description,
                Price = request.Price,
                Name = request.Name,
                Stock = request.Stock,
                Status = request.Status
            });

            return Ok();
        }
    }
}
