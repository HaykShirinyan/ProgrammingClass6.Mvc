using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomWebsite.Models
{
	public class CartItems
	{
		[Key]
		public int Id {get; set;}

		public int ProductId {get; set;}

		public string User {get; set;}
	}
}