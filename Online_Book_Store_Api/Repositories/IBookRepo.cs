using Book_Store_Api.Models;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_Store_Api.Repositories
{
	public interface IBookRepo
	{
		List<Book> GetAllBooks();
		Book GetBooksByISBN(int ISBN);
		public string AddnewBooks(Book books);
		public string UpdateBooks(Book books);
		public string DeleteBooks(int ISBN);
	}
}
