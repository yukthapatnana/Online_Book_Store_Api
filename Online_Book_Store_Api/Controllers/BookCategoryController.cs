using Book_Store_Api.Models;
using Book_Store_Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book_Store_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookCategoryController : ControllerBase
	{
		private readonly IBookCategoryRepo Repositories = null;
		public BookCategoryController(IBookCategoryRepo repo)
		{
			Repositories = repo;
		}
		[HttpGet]
		public ActionResult<List<BookCategory>> Get()
		{
			List<BookCategory> category = Repositories.GetBookCategories();
			if (category.Count > 0)
			{
				return category;
			}
			else
			{
				return NotFound();
			}
		}
		[Route("{id:int}")]
		[HttpGet]
		public ActionResult<BookCategory> Get(int id)
		{
			BookCategory category = Repositories.GetCategoryById(id);
			if (category != null)
			{
				return category;
			}
			else
			{
				return NotFound();
			}
		}
		[HttpPost]
		public string Post(BookCategory category)
		{
			string Response = Repositories.AddnewCategory(category);
			return Response;
		}
		[HttpPut]
		public string Put(BookCategory category)
		{
			string Response = Repositories.UpdateCategory(category);
			return Response;
		}
		[Route("{id:int}")]
		[HttpDelete]
		public string Delete(int id)
		{
			string Response = Repositories.DeleteCategory(id);
			return Response;
		}
	}
}

