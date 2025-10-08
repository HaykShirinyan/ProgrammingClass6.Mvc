using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass6.Mvc.Models
{
    public class Color
    {
        [Key]   
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public required string Name { get; set; }
        [StringLength(500)]
        public required string Description { get; set; }
    }
}
