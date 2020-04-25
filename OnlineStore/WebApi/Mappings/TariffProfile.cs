using AutoMapper;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Dtos;
using OnlineStore.WebApi.ViewModels;

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
