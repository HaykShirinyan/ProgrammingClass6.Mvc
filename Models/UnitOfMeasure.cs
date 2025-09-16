namespace ProgrammingClass6.Mvc.Models
{
    public class UnitOfMeasure
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required string Type { get; set; }

        public decimal UnitOfMeasureValue { get; set; }

        public decimal Price { get; set; }
    }
}
