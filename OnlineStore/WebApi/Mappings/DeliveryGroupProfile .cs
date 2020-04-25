using AutoMapper;
using OnlineStore.Domain.Models;
using OnlineStore.WebApi.ViewModels;

namespace OnlineStore.WebApi.Mappings
{
	public class DeliveryGroupProfile : Profile
	{
		public DeliveryGroupProfile()
		{
			this.CreateMap<DeliveryGroup, DeliveryGroupModel>();
			this.CreateMap<DeliveryGroupModel, DeliveryGroup>();
		}
	}
}
