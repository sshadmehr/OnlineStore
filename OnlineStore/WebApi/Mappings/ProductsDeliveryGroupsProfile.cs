using AutoMapper;
using OnlineStore.Domain.Models;
using OnlineStore.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.WebApi.Mappings
{
	public class ProductsDeliveryGroupsProfile : Profile
	{
		public ProductsDeliveryGroupsProfile()
		{
			this.CreateMap<ProductsDeliveryGroups, ProductsDeliveryGroupsModel>();
			this.CreateMap<ProductsDeliveryGroupsModel, ProductsDeliveryGroups>();
		}
	}
}
