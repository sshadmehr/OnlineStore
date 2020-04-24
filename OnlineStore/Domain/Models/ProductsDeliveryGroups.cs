using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Models
{
	public class ProductsDeliveryGroups
	{
		public int ProductId { get; set; }
		public int DeliveryGroupId { get; set; }
		public Product Product { get; set; }
		public DeliveryGroup DeliveryGroup { get; set; }
	}
}
