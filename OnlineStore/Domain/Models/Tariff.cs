using OnlineStore.Domain.Enums;
using System;

namespace OnlineStore.Domain.Models
{
	public class Tariff: ILogicalDeletable
	{
		public int Id { get; set; }
		public DateTime EffectiveDate { get; set; }
		public int Price { get; set; }
		public int DeliveryGroupId { get; set; }
		public DeliveryGroup DeliveryGroup { get; set; }
		public DeliveryType DeliveryType { get; set; }
		public bool Deleted { get; set; }
	}
}
