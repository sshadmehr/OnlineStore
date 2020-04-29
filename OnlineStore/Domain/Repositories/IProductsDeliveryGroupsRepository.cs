using System.Collections.Generic;
using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Repositories
{
	public interface IProductsDeliveryGroupsRepository : IBaseEntityRepository<ProductsDeliveryGroups>
	{
		IEnumerable<ProductsDeliveryGroups> GetByProduct(int productId);
		IEnumerable<ProductsDeliveryGroups> GetByDeliveryGroup(int deliveryGroupId);
		void Delete(int id);
		void InsertRange(IEnumerable<ProductsDeliveryGroups> productsDeliveryGroups);
		void DeleteRange(IEnumerable<ProductsDeliveryGroups> productsDeliveryGroups);
	}

}
