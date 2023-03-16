using Book_Store_Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Book_Store_Api.Repositories
{
	public class LoginRepo : ILoginRepo
	{
		private MyDbContext context;

		public LoginRepo(MyDbContext _context)
		{
			context = _context;
		}
		public List<Login> GetAllLogins()
		{
			return context.Logins.ToList();
		}
		public Login GetLoginById(int id)
		{
			Login login = context.Logins.Find(id);
			return login;
		}

		public string AddnewLogin(Login login)
		{
			int count = context.Logins.Count();
			context.Logins.Add(login);
			context.SaveChanges();
			int newcount = context.Logins.Count();
			if (newcount > count)
			{
				return "Login Successful";
			}
			else
			{
				return "oops something went wrong while login";
			}
		}
		public string UpdateLogin(Login login)
		{
			Login updatelogin = context.Logins.Find(login.Log_Id);
			if (updatelogin != null)
			{
				updatelogin.Email = login.Email;
				context.Logins.Update(updatelogin);
				context.SaveChanges();
				return "Login details updated Successfully";
			}
			else
			{
				return "Given Login is not available to update";
			}
		}

		public string DeleteLogin(int logid)
		{
			Login log = context.Logins.Find(logid);
			if (log != null)
			{
				context.Logins.Remove(log);
				context.SaveChanges();
				return "Login removed from Database";
			}
			else
			{
				return "Given login is not available";
			}
		}

	}
}

