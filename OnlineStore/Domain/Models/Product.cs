using System;
using System.Collections.Generic;

namespace OnlineStore.Domain.Models
{
	public class Product : BaseEntity, ILogicalDeletable
	{
		public Product()
		{
			this.ProductsDeliveryGroups = new HashSet<ProductsDeliveryGroups>();
		}
		public string Model { get; set; }
		public DateTime RegisterDate { get; set; }
		public int ProductGroupId { get; set; }
		public ProductGroup ProductGroup { get; set; }
		public ICollection<ProductsDeliveryGroups> ProductsDeliveryGroups { get; set; }
		public bool Deleted { get; set; }
	}
}
