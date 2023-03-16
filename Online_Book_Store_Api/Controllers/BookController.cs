using Book_Store_Api.Models;
using Book_Store_Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_Store_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly IBookRepo Repositories = null;
		public BookController(IBookRepo repo)
		{
			Repositories = repo;
		}
		[HttpGet]
		public ActionResult<List<Book>> Get()
		{
			List<Book> books = Repositories.GetAllBooks();
			if (books.Count > 0)
			{
				return books;
			}
			else
			{
				return NotFound();
			}
		}
		[Route("{id:int}")]
		[HttpGet]
		public ActionResult<Book> Get(int ISBN)
		{
			Book books = Repositories.GetBooksByISBN(ISBN);
			if (books != null)
			{
				return books;
			}
			else
			{
				return NotFound();
			}
		}
		[HttpPost]
		public string Post(Book books)
		{
			string Response = Repositories.AddnewBooks(books);
			return Response;
		}
		[HttpPut]
		public string Put(Book books)
		{
			string Response = Repositories.UpdateBooks(books);
			return Response;
		}
		[Route("{id:int}")]
		[HttpDelete]
		public string Delete(int ISBN)
		{
			string Response = Repositories.DeleteBooks(ISBN);
			return Response;
		}
	}
}

