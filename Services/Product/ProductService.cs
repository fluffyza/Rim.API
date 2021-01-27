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
	public class ProductService : BaseService, IProductService
	{

		public ProductService(Context context,
			IMapper mapper, ILogger<ProductService> logger) : base(context, mapper, logger)
		{
		}

		public ProductPagedModel GetPagedProduct(int page, int pageSize)
		{
			try
			{
				var count = _context.Product.Where(x => x.IsActive).Count();
				return new ProductPagedModel()
				{
					Products = _mapper.Map<List<ProductModel>>(
						_context.Product.Where(x => x.IsActive && x.StockCount > 0)
						.Skip(pageSize * (page - 1)).Take(pageSize).ToList()),
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
				return new ProductPagedModel();
			}
		}

		public List<ProductModel> GetAllProducts()
		{
			try
			{
				return _mapper.Map<List<ProductModel>>
					(_context.Product.Where(x => x.IsActive).ToList());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex.StackTrace);
				return new List<ProductModel>();
			}
		}


		public ProductModel GetProductById(int id)
		{
			try
			{
				return _mapper.Map<ProductModel>
					(_context.Product.Where(x => x.IsActive).FirstOrDefault(x => x.Id == id));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex.StackTrace);
				return new ProductModel();
			}
		}

		public bool UpdateProduct(ProductModel productModel)
		{
			try
			{
				Product product =
					_mapper.Map<Product>(productModel);
				_context.Entry(product).State = EntityState.Modified;
				_context.Product.Update(product);
				_context.SaveChanges();
				return true;
			}
			catch (DbUpdateConcurrencyException ex)
			{
				_logger.LogError(ex.Message, ex.StackTrace);
				return false;
			}
		}

		public bool DeleteProductById(int id)
		{
			try
			{
				Product product =
					_context.Product.FirstOrDefault(x => x.Id == id);
				if (product == null)
					return false;
				product.IsActive = false;
				_context.Entry(product).State = EntityState.Modified;
				_context.Product.Update(product);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex.StackTrace);
				return false;
			}
		}

		public ProductModel InsertProduct(ProductModel productModel)
		{
			try
			{
				Product entity =
					_context.Product.Add(_mapper.Map<Product>
					(productModel)).Entity;
				_context.SaveChanges();
				_context.Dispose();
				return _mapper.Map<ProductModel>(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex.StackTrace);
				return new ProductModel();
			}
		}

	}
}