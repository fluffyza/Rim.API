
using Microsoft.AspNetCore.Mvc;
using Rim.API.Models;
using Rim.API.Services.Interface;
using System.Collections.Generic;

namespace Rim.API.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class OrderController : Controller
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		/// <summary>
		/// Get Paged Order
		/// </summary>
		/// <param name="page"></param>
		/// <param name="pageSize"></param>
		/// <returns>List<OrderModel></returns>
		[HttpGet]
		public OrderPagedModel GetPagedOrder(int page, int pageSize) =>
			_orderService.GetPagedOrder(page, pageSize);

		/// <summary>
		/// Get Order By Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns>OrderModel</returns>
		[HttpGet]
		public OrderModel GetOrderById(int id) =>
			_orderService.GetOrderById(id);

		/// <summary>
		/// Update Order
		/// </summary>
		/// <param name="orderModel"></param>
		/// <returns>bool</returns>
		[HttpPut]
		public bool UpdateOrder(OrderModel orderModel) =>
			_orderService.UpdateOrder(orderModel);

		/// <summary>
		/// Delete Order By Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns>bool</returns>
		[HttpDelete]
		public bool DeleteOrderById(int id) =>
			_orderService.DeleteOrderById(id);

		/// <summary>
		/// Insert Order
		/// </summary>
		/// <param name="orderModel"></param>
		/// <returns>OrderModel</returns>
		[HttpPost]
		public OrderModel InsertOrder(OrderModel orderModel) =>
			_orderService.InsertOrder(orderModel);

	}
}
