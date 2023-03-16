using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_Store_Api.Models
{
	public class OrderDetails
	{
		[Key]
		public int OrderId { get; set; }
		public DateTime OrderDate { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public int Quantity { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		[Display(Name = "Phone_no")]
		public long Phone { get; set; }
		public decimal TotalPrice { get; set; }
		public Registration Registration { get; set; }
		public Book Books { get; set; }
		public ICollection<Payment> Payments { get; set; } 
	}
}
