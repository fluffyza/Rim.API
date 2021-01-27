using Rim.API.Models;
using System.Collections.Generic;


namespace Rim.API.Services.Interface
{
	public interface IProductService
	{
		ProductPagedModel GetPagedProduct(int page, int pageSize);
		ProductModel GetProductById(int id);
		bool UpdateProduct(ProductModel productModel);
		bool DeleteProductById(int id);
		ProductModel InsertProduct(ProductModel productModel);
		List<ProductModel> GetAllProducts();
	}
}
