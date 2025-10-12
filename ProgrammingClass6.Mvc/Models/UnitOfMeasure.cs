using ProgrammingClass6.Mvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass6.Mvc.Models
{



    public class UnitOfMeasure
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}