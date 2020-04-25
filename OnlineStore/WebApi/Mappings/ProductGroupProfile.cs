using AutoMapper;
using OnlineStore.Domain.Models;
using OnlineStore.WebApi.ViewModels;

namespace OnlineStore.WebApi.Mappings
{
	public class ProductGroupProfile : Profile
	{
		public ProductGroupProfile()
		{
			this.CreateMap<ProductGroup, ProductGroupModel>();
			this.CreateMap<ProductGroupModel, ProductGroup>();
		}
	}
}
