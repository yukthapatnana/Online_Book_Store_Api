using Book_Store_Api.Models;
using System.Collections.Generic;

namespace Book_Store_Api.Repositories
{
	public interface ILoginRepo
	{
		List<Login> GetAllLogins();
		Login GetLoginById(int id);
		string AddnewLogin(Login login);
		string UpdateLogin(Login login);
		string DeleteLogin(int logid);
	}
}
