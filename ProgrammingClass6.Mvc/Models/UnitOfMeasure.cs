using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass6.Mvc.Models
{
    public class UnitOfMeasure
    {
        [Key]
        public int Id { get; set; }

        public string UnitName { get; set; }

        [StringLength(10)]
        public string UnitShortName { get; set; }
     
        public int Diametere { get; set; }
    }
}
