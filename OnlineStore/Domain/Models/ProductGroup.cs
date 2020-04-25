﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Models
{
	public class ProductGroup : BaseEntity, ILogicalDeletable
	{
		public ProductGroup()
		{
			this.Products = new HashSet<Product>();
		}
		public Nullable<int> ParentId { get; set; }
		public ICollection<Product> Products { get; set; }
		public bool Deleted { get; set; }
	}
}
