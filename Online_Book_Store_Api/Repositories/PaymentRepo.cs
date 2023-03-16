using Book_Store_Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Book_Store_Api.Repositories
{
	public class PaymentRepo : IPaymentRepo
	{
		private MyDbContext context;
		public PaymentRepo(MyDbContext _context)
		{
			context = _context;
		}
		public List<Payment> GetAllPayments()
		{
			return context.Payment.ToList();
		}
		public Payment GetPaymentById(int id)
		{
			Payment payment = context.Payment.Find(id);
			return payment;
		}

		public string AddnewPayment(Payment payment)
		{
			int count = context.Payment.Count();
			context.Payment.Add(payment);
			context.SaveChanges();
			int newcount = context.Payment.Count();
			if (newcount > count)
			{
				return "Payment Successfully";
			}
			else
			{
				return "Something went wrong while adding payment details";
			}
		}
		public string UpdatePayment(Payment payment)
		{
			Payment updatepayment = context.Payment.Find(payment.PaymentId);
			if (updatepayment != null)
			{
				updatepayment.PaymentMethod = payment.PaymentMethod;
				context.Payment.Update(updatepayment);
				context.SaveChanges();
				return "Payment details are updated";
			}
			else
			{
				return "Unable update the payment details";
			}
		}

		public string DeletePayment(int id)
		{
			Payment payment = context.Payment.Find(id);
			if (payment != null)
			{
				context.Payment.Remove(payment);
				context.SaveChanges();
				return "Payment details are removed from database";
			}
			else
			{
				return "Unable remove the payment details from database";
			}
		}

	}
}