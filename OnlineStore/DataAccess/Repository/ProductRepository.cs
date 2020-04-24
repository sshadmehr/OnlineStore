using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Repository
{
	public class ProductRepository : BaseLogicalDeletableRepository<Product>, IProductRepository
	{
		public ProductRepository(OnlineStoreContext context) : base(context)
		{

		}

		public Product Load(int id)
		{
			return this.context.Products
				.Include(x => x.ProductsDeliveryGroups)
				.Include(x => x.ProductGroup)
				.FirstOrDefault(x => x.Id == id);
				
				
		}
	}
}
