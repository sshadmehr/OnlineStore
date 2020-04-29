using OnlineStore.Domain.Models;
using OnlineStore.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.DataAccess.Repository
{

	public class ProductsDeliveryGroupsRepository : BaseEntityRepository<ProductsDeliveryGroups>, IProductsDeliveryGroupsRepository
	{
		public ProductsDeliveryGroupsRepository(OnlineStoreContext context) : base(context)
		{

		}

		public void Delete(int id)
		{
			var entityToDelete = dbSet.Find(id);
			Delete(entityToDelete);
		}

		public IEnumerable<ProductsDeliveryGroups> GetByDeliveryGroup(int deliveryGroupId)
		{
			return dbSet.Where(x => x.DeliveryGroupId == deliveryGroupId);
		}

		public IEnumerable<ProductsDeliveryGroups> GetByProduct(int productId)
		{
			return dbSet.Where(x => x.ProductId == productId);
		}

		public void InsertRange(IEnumerable<ProductsDeliveryGroups> productsDeliveryGroups)
		{
			dbSet.AddRange(productsDeliveryGroups);
		}
		public void DeleteRange(IEnumerable<ProductsDeliveryGroups> productsDeliveryGroups)
		{
			dbSet.RemoveRange(productsDeliveryGroups);
		}
	}

}
