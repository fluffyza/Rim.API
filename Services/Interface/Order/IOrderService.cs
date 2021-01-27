using Rim.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rim.API.Services.Interface
{
	public interface IOrderService
	{
		OrderPagedModel GetPagedOrder(int page, int pageSize);
		OrderModel GetOrderById(int id);
		bool UpdateOrder(OrderModel orderModel);
		bool DeleteOrderById(int id);
		OrderModel InsertOrder(OrderModel orderModel);
	}
}
