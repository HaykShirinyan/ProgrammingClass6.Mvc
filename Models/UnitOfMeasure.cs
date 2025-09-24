using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingClass6.Mvc.Models
{
    public class UnitOfMeasure
    {
        [key]   
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public required string Name { get; set; }
        [SrtingLenght(500)] 
        public required string Type { get; set; }

        public decimal UnitOfMeasureValue { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity{ get; set; }

        [ForeignKey(nameof(UnitOfMeasure))]
        public int? ManufactureId { get; set; }

        public required Manufacture Manufacture { get; set; }
    }
}
