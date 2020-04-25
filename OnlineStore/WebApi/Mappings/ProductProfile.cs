using AutoMapper;
using OnlineStore.Domain.Models;
using OnlineStore.WebApi.ViewModels;

namespace OnlineStore.WebApi.Mappings
{
	public class ProductProfile: Profile
	{
		public ProductProfile()
		{
			this.CreateMap<Product, ProductModel>();
			this.CreateMap<ProductModel, Product>();
		}
	}
}
