using Productos.Domain.Enums;

namespace Productos.Domain.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public ProductStatus Status { get; set; }

        public int Stock { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }
    }
}
