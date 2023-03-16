using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store_Api.Models
{
	public class Registration
	{
		public int RegistrationId { get; set; }
		[Required]
		public string Name { get; set; }
		[Required, EmailAddress]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[NotMapped]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Password and confirmpassword should be same")]
		public string confirmPassword { get; set; }
		[Required]
		[Display(Name = "Mobile_No")]
		public long Phone { get; set; }
		public ICollection<Login> Logins { get; set; }
		public ICollection<OrderDetails> OrderDetails { get; set; }

	}
}
