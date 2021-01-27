
using AutoMapper;
using Rim.API.Entities;
using Rim.API.Models;

namespace Rim.API.Mapper
{
	public class AutoMapping : Profile
	{
		public AutoMapping()
		{
			CreateMap<Product, ProductModel>()
				.ReverseMap();
			CreateMap<Order, OrderModel>()
				.ReverseMap();
		}
	}
}
