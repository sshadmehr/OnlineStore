﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Models
{
	public class DeliveryGroup : BaseEntity, ILogicalDeletable
	{
		public ICollection<ProductsDeliveryGroups> ProductsDeliveryGroups { get; set; }
		public bool Deleted { get; set; }
	}
}