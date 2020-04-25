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

		public bool IsNameDuplicated(Product product)
		{
			bool result = true;
			if (product.Id > 0)
			{
				result = (context.Products.Where(x => x.Name == product.Name &&
																							x.Id != product.Id
																							)).Count() > 0;
			}
			else
			{
				result = (context.Products.Where(x => x.Name == product.Name)).Count() > 0;
			}
			return result;
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
