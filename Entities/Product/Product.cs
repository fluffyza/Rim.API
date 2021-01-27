
using System;
using System.Collections.Generic;

namespace Rim.API.Entities
{
	public class Product
	{
		public Product()
		{
			Order = new HashSet<Order>();
		}
		public int Id { get; set; }
		public Guid ProductGuid { get; set; }
		public string ProductTitle { get; set; }
		public double ProductPrice { get; set; }
		public int StockCount { get; set; }
		public bool IsActive { get; set; }
		public virtual ICollection<Order> Order { get; set; }
	}
}
