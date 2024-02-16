using Productos.Application.Features.Products.Commands.CreateProduct;
using Productos.Application.Features.Products.Commands.UpdateProduct;
using Productos.Application.Features.Products.Querys.GetProductById;
using Productos.Domain.Entities;

namespace Productos.Application.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetProductByIdVm>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
