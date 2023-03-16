using Book_Store_Api.Models;
using Book_Store_Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.Collections.Generic;

namespace Book_Store_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegistrationController : ControllerBase
	{
		private readonly IRegistrationRepo Repositories = null;
		public RegistrationController(IRegistrationRepo repo)
		{
			Repositories = repo;
		}
		[HttpGet]
		public ActionResult<List<Registration>> Get()
		{
			List<Registration> registrations = Repositories.GetAllRegistrations();
			if (registrations.Count > 0)
			{
				return registrations;
			}
			else
				return NotFound();
		}
		[Route("{id:int}")]
		[HttpGet]
		public ActionResult<Registration> Get(int id)
		{
			Registration registration = Repositories.GetRegistrationById(id);
			if (registration != null)
			{
				return registration;
			}
			else
				return NotFound();
		}
		[HttpPost]
		public string Post(Registration registration)
		{
			string Response = Repositories.AddnewRegistration(registration);
			return Response;
		}
		[HttpPut]
		public string Put(Registration registration)
		{
			string Response = Repositories.UpdateRegistration(registration);
			return Response;
		}
		[Route("{id:int}")]
		[HttpDelete]
		public string Delete(int id)
		{
			string Response = Repositories.DeleteRegistration(id);
			return Response;
		}
	}
}
