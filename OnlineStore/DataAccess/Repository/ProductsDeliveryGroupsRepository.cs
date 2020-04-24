using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineStore.DataAccess.Repository
{

	public class ProductsDeliveryGroupsRepository : BaseEntityRepository<ProductsDeliveryGroups>, IProductsDeliveryGroupsRepository
	{
		public ProductsDeliveryGroupsRepository(OnlineStoreContext context) : base(context)
		{

		}

		public void Delete(int id)
		{
			ProductsDeliveryGroups entityToDelete = dbSet.Find(id);
			Delete(entityToDelete);
		}

		public IEnumerable<ProductsDeliveryGroups> GetByDeliveryGroup(int deliveryGroupId)
		{
			return dbSet.Where(x => x.DeliveryGroupId == deliveryGroupId);
		}

		public IEnumerable<ProductsDeliveryGroups> GetByPtoduct(int productId)
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
