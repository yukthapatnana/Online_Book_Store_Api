using Book_Store_Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Book_Store_Api.Repositories
{
	public class BookCategoryRepo : IBookCategoryRepo
	{
		private MyDbContext context;
		public BookCategoryRepo(MyDbContext _context)
		{
			context = _context;
		}
		public List<BookCategory> GetBookCategories()
		{
			return context.BookCategories.ToList();
		}
		public BookCategory GetCategoryById(int id)
		{
			BookCategory bookCategory = context.BookCategories.Find(id);
			return bookCategory;
		}
		public string AddnewCategory(BookCategory category)
		{
			int count = context.BookCategories.Count();
			context.BookCategories.Add(category);
			context.SaveChanges();
			int newcount = context.BookCategories.Count();
			if (newcount > count)
			{
				return "Category added successfully";
			}
			else
			{
				return "o0ps something went wrong while adding category";
			}
		}
		public string UpdateCategory(BookCategory category)
		{
			BookCategory updatecategory = context.BookCategories.Find(category.CategoryId);
			if (updatecategory != null)
			{
				updatecategory.Category = category.Category;
				context.BookCategories.Update(updatecategory);
				context.SaveChanges();
				return "Category of books are updated";
			}
			else
			{
				return "Category of books are not available";
			}
		}

		public string DeleteCategory(int cate_id)
		{
			BookCategory category = context.BookCategories.Find(cate_id);
			if (category != null)
			{
				context.BookCategories.Remove(category);
				context.SaveChanges();
				return "BookCategory is removed from Database";
			}
			else
			{
				return "Bookcategory is not removed from Database";
			}
		}
	}
}
