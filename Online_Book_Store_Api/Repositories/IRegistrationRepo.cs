using Book_Store_Api.Models;
using System.Collections.Generic;

namespace Book_Store_Api.Repositories
{
	public interface IRegistrationRepo
	{
		List<Registration> GetAllRegistrations();
		Registration GetRegistrationById(int id);
		string AddnewRegistration(Registration registration);
		string UpdateRegistration(Registration registration);
		string DeleteRegistration(int registid);
	}
}
