namespace Productos.Application.Features.Products.Querys.GetProductById
{
    public class GetProductByIdVm
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string StatusName { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal FinalPrice
        {
            get
            {
                return Price * (100 - Discount) / 100;
            }
        }
    }
}
