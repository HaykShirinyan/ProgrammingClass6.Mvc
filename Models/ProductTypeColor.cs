namespace ProgrammingClass6.Mvc.Models
{
    public class ProductTypeColor
    {
        public int ProductTypeId { get; set; }
        public required ProductType ProductType { get; set; }
        public int ColorId { get; set; }
        public required Color Color { get; set; }
    }
}
