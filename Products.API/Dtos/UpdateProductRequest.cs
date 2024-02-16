using Productos.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Products.API.Dtos
{
    public class UpdateProductRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        [EnumDataType(typeof(ProductStatus))]
        public ProductStatus Status { get; set; }
    }
}
