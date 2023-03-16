using Book_Store_Api.Models;
using System.Collections.Generic;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_Store_Api.Repositories
{
	public class BooksRepo : IBookRepo
	{
		private MyDbContext context;
		public BooksRepo(MyDbContext _context)
		{
			context = _context;
		}
		public List<Book> GetAllBooks()
		{
			return context.Books.ToList();
		}
		public Book GetBooksByISBN(int ISBN)
		{
			Book books = context.Books.Find(ISBN);
			return books;
		}
		public string AddnewBooks(Book books)
		{
			int count = context.Books.Count();
			context.Books.Add(books);
			context.SaveChanges();
			int newcount = context.Books.Count();
			if (newcount > count)
			{
				return "Books added Successfully";
			}
			else
			{
				return "Something went wrong while adding books";
			}
		}
		public string UpdateBooks(Book books)
		{
			Book updatebooks = context.Books.Find(books.ISBN);
			if (updatebooks != null)
			{
				updatebooks.Title = books.Title;
				updatebooks.Price = books.Price;
				context.Books.Update(updatebooks);
				context.SaveChanges();
				return "Books information is updated";
			}
			else
			{
				return "Books information is not available";
			}
		}

		public string DeleteBooks(int ISBN)
		{
			Book books = context.Books.Find(ISBN);
			if (books != null)
			{
				context.Books.Remove(books);
				context.SaveChanges();
				return "Book information is removed from Database";
			}
			else
			{
				return "Book information is not removed from database";
			}
		}
	}
}
