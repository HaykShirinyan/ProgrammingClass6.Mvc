namespace ProgrammingClass6.Mvc.Models
{
    public class ProductSizeMiddleTable
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductSizeId { get; set; }
        public ProductSize ProductSize { get; set; }
    }
}
