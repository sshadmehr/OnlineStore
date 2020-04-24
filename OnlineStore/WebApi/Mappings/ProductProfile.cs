using AutoMapper;
using OnlineStore.Domain.Models;
using OnlineStore.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
