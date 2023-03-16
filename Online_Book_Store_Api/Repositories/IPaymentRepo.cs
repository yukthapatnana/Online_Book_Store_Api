using Book_Store_Api.Models;
using System.Collections.Generic;

namespace Book_Store_Api.Repositories
{
	public interface IPaymentRepo
	{
		List<Payment> GetAllPayments();
		Payment GetPaymentById(int id);
		public string AddnewPayment(Payment payment);
		public string UpdatePayment(Payment payment);
		public string DeletePayment(int id);
	}
}
