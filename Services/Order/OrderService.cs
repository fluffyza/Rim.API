using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rim.API.Entities;
using Rim.API.Models;
using Rim.API.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rim.API.Services
{
	public class OrderService : BaseService, IOrderService
	{

		public OrderService(Context context,
			IMapper mapper, ILogger<OrderService> logger) : base(context, mapper, logger)
		{
		}

		public OrderPagedModel GetPagedOrder(int page, int pageSize)
		{
			try
			{
				var count = _context.Order.Where(x => x.IsActive).Count();
				return new OrderPagedModel()
				{
					Orders = (from orders in _context.Order
							  where orders.IsActive == true
							  select new OrderAdvancedModel()
							  {
								  Order = _mapper.Map<OrderModel>(orders),
								  Product = _mapper.Map<ProductModel>(_context.Product.FirstOrDefault(x => x.Id == orders.ProductId))
							  }).Skip(pageSize * (page - 1)).Take(pageSize).ToList(),
					Pagination = new PaginationModel()
					{
						PageNumber = page,
						PageSize = pageSize,
						TotalResults = count,
						TotalPageCount = Math.Ceiling(Convert.ToDouble(count) / Convert.ToDouble(pageSize))
					}
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex.StackTrace);
				return new OrderPagedModel();
			}
		}

		public OrderModel GetOrderById(int id)
		{
			try
			{
				return _mapper.Map<OrderModel>
					(_context.Order.FirstOrDefault(x => x.Id == id));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex.StackTrace);
				return new OrderModel();
			}
		}

		public bool UpdateOrder(OrderModel orderModel)
		{
			try
			{
				Order order =
					_mapper.Map<Order>(orderModel);
				_context.Entry(order).State = EntityState.Modified;
				_context.Order.Update(order);
				_context.SaveChanges();
				return true;
			}
			catch (DbUpdateConcurrencyException ex)
			{
				_logger.LogError(ex.Message, ex.StackTrace);
				return false;
			}
		}

		public bool DeleteOrderById(int id)
		{
			try
			{
				Order order =
					_context.Order.FirstOrDefault(x => x.Id == id);
				if (order == null)
					return false;
				order.IsActive = false;
				_context.Entry(order).State = EntityState.Modified;
				_context.Order.Update(order);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex.StackTrace);
				return false;
			}
		}

		public OrderModel InsertOrder(OrderModel orderModel)
		{
			try
			{
				Order entity =
					_context.Order.Add(_mapper.Map<Order>
					(orderModel)).Entity;
				Product prod = _context.Product.FirstOrDefault(x => x.Id == orderModel.ProductId);
				prod.StockCount -= 1;
				_context.Entry(prod).State = EntityState.Modified;
				_context.Product.Update(prod);
				_context.SaveChanges();
				_context.Dispose();
				return _mapper.Map<OrderModel>(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex.StackTrace);
				return new OrderModel();
			}
		}

	}
}