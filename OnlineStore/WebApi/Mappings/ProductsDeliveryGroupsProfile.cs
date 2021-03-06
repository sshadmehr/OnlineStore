﻿using AutoMapper;
using OnlineStore.Domain.Models;
using OnlineStore.WebApi.ViewModels;

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
