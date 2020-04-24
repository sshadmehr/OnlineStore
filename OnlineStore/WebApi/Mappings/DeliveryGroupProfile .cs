﻿using AutoMapper;
using OnlineStore.Domain.Models;
using OnlineStore.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
