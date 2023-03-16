using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Book_Store_Api.Models
{
	public class Book
	{
		[Key]
		public int ISBN { get; set; }
		[Required]
		public string Title { get; set; }
		public string Author { get; set; }
		public decimal Price { get; set; }
		public BookCategory BookCategory { get; set; }
		public ICollection<OrderDetails> OrderDetails { get; set; }
	}
}

