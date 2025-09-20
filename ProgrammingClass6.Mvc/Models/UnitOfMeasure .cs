using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass6.Mvc.Models
{
    public class UnitOfMeasure
{
    // Primary Key for the UnitOfMeasure table
    [Key]
    public int Id { get; set; }

    // Full name of the unit (e.g., "Kilogram")
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    // Short symbol for the unit (e.g., "kg")
    [Required]
    [StringLength(10)]
    public string Symbol { get; set; }

    // The type of measurement (e.g., "Weight", "Volume")
    [Required]
    [StringLength(50)]
    public string UnitType { get; set; }

    // Conversion factor relative to the base unit of its type (e.g., 1000 for "gram" to "kilogram")
    public decimal ConversionFactor { get; set; } = 1.0m;

    // Indicates if this is the base unit for its UnitType
    public bool IsBaseUnit { get; set; } = false;

    // Flag to indicate if the unit is currently active
    public bool IsActive { get; set; } = true;

    // Navigation property to hold all products using this unit
    public virtual ICollection<Product>? Products { get; set; }
}

}