using Book_Store_Api.Models;
using System.Collections.Generic;

namespace Book_Store_Api.Repositories
{
	public interface IBookCategoryRepo
	{
		List<BookCategory> GetBookCategories();
		BookCategory GetCategoryById(int id);
		public string AddnewCategory(BookCategory category);
		public string UpdateCategory(BookCategory category);
		public string DeleteCategory(int cate_id);

	}
}
