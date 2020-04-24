using OnlineStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.WebApi.ViewModels
{
	public class TariffModel
	{
		public int Id { get; set; }
		public DateTime EffectiveDate { get; set; }
		public float Price { get; set; }
		public int DeliveryGroupId { get; set; }
		public DeliveryGroupModel DeliveryGroup { get; set; }
		public DeliveryType DeliveryType { get; set; }
		public bool Deleted { get; set; }

	}
}
