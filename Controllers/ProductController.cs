
using Microsoft.AspNetCore.Mvc;
using Rim.API.Models;
using Rim.API.Services.Interface;
using System.Collections.Generic;

namespace Rim.API.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		/// <summary>
		/// Get Paged Product
		/// </summary>
		/// <param name="page"></param>
		/// <param name="pageSize"></param>
		/// <returns>List<ProductModel></returns>
		[HttpGet]
		public ProductPagedModel GetPagedProduct(int page, int pageSize) =>
			_productService.GetPagedProduct(page, pageSize);

		/// <summary>
		/// Get All Products
		/// </summary>
		/// <returns>List<ProductModel></returns>
		[HttpGet]
		public List<ProductModel> GetAllProducts() =>
			_productService.GetAllProducts();

		/// <summary>
		/// Get Product By Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns>ProductModel</returns>
		[HttpGet]
		public ProductModel GetProductById(int id) =>
			_productService.GetProductById(id);

		/// <summary>
		/// Update Product
		/// </summary>
		/// <param name="productModel"></param>
		/// <returns>bool</returns>
		[HttpPut]
		public bool UpdateProduct(ProductModel productModel) =>
			_productService.UpdateProduct(productModel);

		/// <summary>
		/// Delete Product By Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns>bool</returns>
		[HttpDelete]
		public bool DeleteProductById(int id) =>
			_productService.DeleteProductById(id);

		/// <summary>
		/// Insert Product
		/// </summary>
		/// <param name="productModel"></param>
		/// <returns>ProductModel</returns>
		[HttpPost]
		public ProductModel InsertProduct(ProductModel productModel) =>
			_productService.InsertProduct(productModel);

	}
}
