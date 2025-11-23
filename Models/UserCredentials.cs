using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomWebsite.Models
{
	public class UserCredentials
	{
		[Key]
		public int Id {get; set;}

		public string Email {get; set;}

		public string Country {get; set;}

		public string City {get; set;}

		public string Street {get; set;}

		public string PostalCode {get; set;}

		public string CardNumber {get; set;}

		public string CardHolder {get; set;}

		public string CardDate {get; set;}

		public string CardCvc {get; set;}
	}
}