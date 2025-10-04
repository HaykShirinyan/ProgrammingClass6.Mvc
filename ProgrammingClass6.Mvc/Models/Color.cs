using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass6.Mvc.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Colors { get; set; }
    }
}
