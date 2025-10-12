using System.ComponentModel.DataAnnotations;

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

        public decimal UnitePrice { get; set; }

        public bool IsActive { get; set; } = true;
    }
}