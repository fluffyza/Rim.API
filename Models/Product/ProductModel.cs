using System;
using System.Collections.Generic;

namespace Rim.API.Models
{
	public class ProductModel
	{
		public int Id { get; set; }
		public Guid ProductGuid { get; set; }
		public string ProductTitle { get; set; }
		public double ProductPrice { get; set; }
		public int StockCount { get; set; }
		public bool IsActive { get; set; }
	}

	public class ProductPagedModel
	{
		public List<ProductModel> Products { get; set; }
		public PaginationModel Pagination { get; set; }
	}

}
