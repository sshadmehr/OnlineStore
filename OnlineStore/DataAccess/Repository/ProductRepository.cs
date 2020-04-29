using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Repositories;
using System.Linq;

namespace OnlineStore.DataAccess.Repository
{
	public class ProductRepository : BaseLogicalDeletableRepository<Product>, IProductRepository
	{
		public ProductRepository(OnlineStoreContext context) : base(context)
		{

		}

		public bool IsNameDuplicated(Product product)
		{
			bool result;
			if (product.Id > 0)
			{
				result = context.Products.Count(x => x.Name == product.Name &&
																							x.Id != product.Id
																							) > 0;
			}
			else
			{
				result = context.Products.Count(x => x.Name == product.Name) > 0;
			}
			return result;
		}

		public bool IsProductGroupUsed(int productGroupId)
		{
			return context.Products.Count(x => x.ProductGroupId == productGroupId) > 0;
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
