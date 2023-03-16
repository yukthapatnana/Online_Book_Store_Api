using Book_Store_Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Book_Store_Api.Repositories
{
	public class OrderRepo : IOrderRepo
	{
		private MyDbContext context;
		public OrderRepo(MyDbContext _context)
		{
			context = _context;
		}
		public List<OrderDetails> GetAllOrders()
		{
			return context.OrderDetails.ToList();
		}
		public OrderDetails GetOrderById(int id)
		{
			OrderDetails order = context.OrderDetails.Find(id);
			return order;
		}

		public string AddnewOrder(OrderDetails orderdetail)
		{
			int count = context.OrderDetails.Count();
			context.OrderDetails.Add(orderdetail);
			context.SaveChanges();
			int newcount = context.OrderDetails.Count();
			if (newcount > count)
			{
				return "OrderDetails are added";
			}
			else
			{
				return "Something went wrong while adding orderdetails";
			}
		}
		public string UpdateOrder(OrderDetails orderdetails)
		{
			OrderDetails updateorder = context.OrderDetails.Find(orderdetails.OrderId);
			if (updateorder != null)
			{
				updateorder.Address = orderdetails.Address;
				updateorder.Phone = orderdetails.Phone;
				context.OrderDetails.Update(updateorder);
				context.SaveChanges();
				return "OderDetails are Updated";
			}
			else
			{
				return "Oderdetails are not available";
			}
		}

		public string DeleteOrder(int id)
		{
			OrderDetails order = context.OrderDetails.Find(id);
			if (order != null)
			{
				context.OrderDetails.Remove(order);
				context.SaveChanges();
				return "OrderDetails are removed from Database";
			}
			else
			{
				return "OrderDetails are not removed from database";
			}
		}
	}
}
