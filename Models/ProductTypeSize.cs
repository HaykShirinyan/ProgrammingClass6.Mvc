namespace ProgrammingClass6.Mvc.Models

{
    public class ProductTypeSize
    {
        public int ProductTypeId { get; set; }

        public required ProductType ProductType { get; set; }
        public int SizeId { get; set; }
        public required Size Size { get; set; }
    }
}
