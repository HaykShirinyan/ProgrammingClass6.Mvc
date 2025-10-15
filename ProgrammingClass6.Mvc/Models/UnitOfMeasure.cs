using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass6.Mvc.Models
{
    public class UnitOfMeasure
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Type { get; set; }

        public decimal UnitOfMeasureValue { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }
    }
}
