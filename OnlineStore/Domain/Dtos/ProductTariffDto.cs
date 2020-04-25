using OnlineStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Dtos
{
	public class ProductTariffDto 
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int Id { get; set; }
		public DateTime EffectiveDate { get; set; }
		public int Price { get; set; }
		public int DeliveryGroupId { get; set; }
		public DeliveryType DeliveryType { get; set; }
		public bool Deleted { get; set; }
	}
}
