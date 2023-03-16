using Book_Store_Api.Models;
using Book_Store_Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Book_Store_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		private readonly IPaymentRepo Repositories = null;
		public PaymentController(IPaymentRepo repo)
		{
			Repositories = repo;
		}
		[HttpGet]
		public ActionResult<List<Payment>> Get()
		{
			List<Payment> payments = Repositories.GetAllPayments();
			if (payments.Count > 0)
			{
				return payments;
			}
			else
			{
				return NotFound();
			}
		}
		[Route("{id:int}")]
		[HttpGet]
		public ActionResult<Payment> Get(int id)
		{
			Payment payments = Repositories.GetPaymentById(id);
			if (payments != null)
			{
				return payments;
			}
			else
			{
				return NotFound();
			}
		}
		[HttpPost]
		public string Post(Payment payment)
		{
			string Response = Repositories.AddnewPayment(payment);
			return Response;
		}
		[HttpPut]
		public string Put(Payment payment)
		{
			string Response = Repositories.UpdatePayment(payment);
			return Response;
		}
		[Route("{id:int}")]
		[HttpDelete]
		public string Delete(int id)
		{
			string Response = Repositories.DeletePayment(id);
			return Response;
		}

	}
}

