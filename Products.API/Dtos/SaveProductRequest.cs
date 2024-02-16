using System.ComponentModel.DataAnnotations;

namespace Products.API.Dtos
{
    public class SaveProductRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
