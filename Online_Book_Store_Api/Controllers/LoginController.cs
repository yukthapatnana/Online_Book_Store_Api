using Book_Store_Api.Models;
using Book_Store_Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book_Store_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ILoginRepo Repositories = null;
		public LoginController(ILoginRepo repo)
		{
			Repositories = repo;
		}
		[HttpGet]
		public ActionResult<List<Login>> Get()
		{
			List<Login> logins = Repositories.GetAllLogins();
			if (logins.Count > 0)
			{
				return logins;
			}
			else
			{
				return NotFound();
			}
		}
		[Route("{id:int}")]
		[HttpGet]
		public ActionResult<Login> Get(int id)
		{
			Login login = Repositories.GetLoginById(id);
			if (login != null)
			{
				return login;
			}
			else
			{
				return NotFound();
			}
		}
		[HttpPost]
		public string Post(Login login)
		{
			string Response = Repositories.AddnewLogin(login);
			return Response;
		}
		[HttpPut]
		public string Put(Login login)
		{
			string Response = Repositories.UpdateLogin(login);
			return Response;
		}
		[Route("{id:int}")]
		[HttpDelete]
		public string Delete(int id)
		{
			string Response = Repositories.DeleteLogin(id);
			return Response;
		}
	}
}

