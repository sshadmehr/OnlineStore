﻿using OnlineStore.Domain.Enums;
using System;

namespace OnlineStore.WebApi.ViewModels
{
	public class ProductTariffModel
	{
		public string ProductName { get; set; }
		public int ProductId { get; set; }
		public int Id { get; set; }
		public DateTime EffectiveDate { get; set; }
		public float Price { get; set; }
		public int DeliveryGroupId { get; set; }
		public DeliveryGroupModel DeliveryGroup { get; set; }
		public DeliveryType DeliveryType { get; set; }
		public bool Deleted { get; set; }

	}
}
