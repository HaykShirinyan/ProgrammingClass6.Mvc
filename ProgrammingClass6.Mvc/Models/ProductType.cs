using ProgrammingClass6.Mvc.Data.Migrations;
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
        public  string Brand { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }


    }
}
