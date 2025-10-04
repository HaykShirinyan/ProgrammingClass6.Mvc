using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingClass6.Mvc.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        [ForeignKey(nameof(UnitOfMeasure))]
        public int? UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}
