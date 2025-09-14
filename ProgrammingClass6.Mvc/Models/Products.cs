using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass6.Mvc.Models
{
	public class Product
	{
		[Key]
		public int Id {get; set;}

		[Required]
		public string ProductName {get; set;}

		public string Brand {get; set;}

		public int Quantity {get; set;}

		public int Price {get; set;}

		public bool InStock {get; set;}
	}
}