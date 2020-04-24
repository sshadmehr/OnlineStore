using AutoMapper;
using OnlineStore.Domain.Models;
using OnlineStore.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
