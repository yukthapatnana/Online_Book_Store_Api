using System.ComponentModel.DataAnnotations;

namespace Book_Store_Api.Models
{
	public class Login
	{
		[Key]
		public int Log_Id { get; set; }
		[Required, EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		public Registration Registration { get; set; }

	}
}

