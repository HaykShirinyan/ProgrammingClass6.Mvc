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
        public string Code { get; set; } 

        [StringLength(1500)]
        public string Description { get; set; } 
        public string ImageUrl { get; set; } 
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        public int? ParentProductTypeId { get; set; } // Nullable foreign key for hierarchy

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; } // Nullable datetime for optional data

        // Navigation property for EF Core to manage the parent-child relationship
        public ProductType? ParentProductType { get; set; }

        // Navigation property for EF Core to manage the one-to-many relationship with products
        public ICollection<Product> Products { get; set; }
    }
}