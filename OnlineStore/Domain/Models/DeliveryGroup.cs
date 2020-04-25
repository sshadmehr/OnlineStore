
using System.Collections.Generic;
namespace OnlineStore.Domain.Models
{
	public class DeliveryGroup : BaseEntity, ILogicalDeletable
	{
		public DeliveryGroup()
		{
			this.ProductsDeliveryGroups = new HashSet<ProductsDeliveryGroups>();
		}
		public ICollection<ProductsDeliveryGroups> ProductsDeliveryGroups { get; set; }
		public bool Deleted { get; set; }
	}
}
