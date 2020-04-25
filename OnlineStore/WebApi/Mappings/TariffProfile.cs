using AutoMapper;
using OnlineStore.Domain.Models;
using OnlineStore.Dtos;
using OnlineStore.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.WebApi.Mappings
{
	public class TariffProfile : Profile
	{
		public TariffProfile()
		{
			this.CreateMap<Tariff, TariffModel>();
			this.CreateMap<TariffModel, Tariff>();
			this.CreateMap<ProductTariffDto, ProductTariffModel>();
			this.CreateMap<ProductTariffModel, ProductTariffDto>();
		}
	}
}
