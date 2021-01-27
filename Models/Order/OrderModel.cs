
using System.Collections.Generic;

namespace Rim.API.Models
{
	public class OrderModel
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public string OrderAddress { get; set; }
		public string OrderRecipient { get; set; }
		public bool OrderCompleted { get; set; }
		public bool OrderCancelled { get; set; }
		public bool IsActive { get; set; }
	}

	public class OrderAdvancedModel
	{
		public OrderModel Order { get; set; }
		public ProductModel Product { get; set; }
	}

	public class OrderPagedModel
	{
		public List<OrderAdvancedModel> Orders { get; set; }
		public PaginationModel Pagination { get; set; }
	}
}
