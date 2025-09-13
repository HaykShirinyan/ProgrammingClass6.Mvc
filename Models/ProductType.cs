
using System.ComponentModel.DataAnnotations;
namespace ProgrammingClass6.Mvc.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Brand { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

    }
}
