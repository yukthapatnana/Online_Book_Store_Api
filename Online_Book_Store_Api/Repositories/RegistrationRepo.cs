using Book_Store_Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Book_Store_Api.Repositories
{
	public class RegistrationRepo : IRegistrationRepo
	{
		private MyDbContext context;
		public RegistrationRepo(MyDbContext _context)
		{
			context = _context;
		}
		public List<Registration> GetAllRegistrations()
		{
			return context.Registrations.ToList();
		}
		public Registration GetRegistrationById(int id)
		{
			Registration registration = context.Registrations.Find(id);
			return registration;
		}

		public string AddnewRegistration(Registration registration)
		{
			int count = context.Registrations.Count();
			context.Registrations.Add(registration);
			context.SaveChanges();
			int newcount = context.Registrations.Count();
			if (newcount > count)
			{
				return "Registration Successful";
			}
			else
			{
				return "oops something went wrong while registration";
			}
		}
		public string UpdateRegistration(Registration registration)
		{
			Registration updateregistration = context.Registrations.Find(registration.RegistrationId);
			if (updateregistration != null)
			{
				updateregistration.Name = registration.Name;
				updateregistration.Email = registration.Email;
				context.Registrations.Update(updateregistration);
				context.SaveChanges();
				return "Registration deatils updated Successfully";
			}
			else
			{
				return "Given Registration is not available to update";
			}
		}
		public string DeleteRegistration(int registid)
		{
			Registration regist = context.Registrations.Find(registid);
			if (regist != null)
			{
				context.Registrations.Remove(regist);
				context.SaveChanges();
				return "Registration removed from Database";
			}
			else
			{
				return "Given Registration is not available";
			}
		}
	}
}