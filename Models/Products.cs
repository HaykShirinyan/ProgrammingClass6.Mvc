using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomWebsite.Models
{
	public class Products
	{
		[Key]
		public int Id {get; set;}

		public string Name {get; set;}

		public string Description {get; set;}
		
		public string Image {get; set;}
		
		public int Price {get; set;}
	}
}