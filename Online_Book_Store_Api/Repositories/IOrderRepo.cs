using Book_Store_Api.Models;
using System.Collections.Generic;

namespace Book_Store_Api.Repositories
{
	public interface IOrderRepo
	{
		List<OrderDetails> GetAllOrders();
		OrderDetails GetOrderById(int id);
		public string AddnewOrder(OrderDetails orderdetail);
		public string UpdateOrder(OrderDetails orderdetail);
		public string DeleteOrder(int id);
	}
}

