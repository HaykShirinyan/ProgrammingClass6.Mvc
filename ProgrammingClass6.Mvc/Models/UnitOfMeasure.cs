using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass6.Mvc.Models
{
    public class UnitOfMeasure
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Unit { get; set; }
    }
}
