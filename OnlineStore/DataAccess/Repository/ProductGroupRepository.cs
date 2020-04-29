using OnlineStore.Domain.Models;
using OnlineStore.Domain.Repositories;
using System.Linq;

namespace OnlineStore.DataAccess.Repository
{
	public class ProductGroupRepository : BaseLogicalDeletableRepository<ProductGroup>, IProductGroupRepository
	{
		public ProductGroupRepository(OnlineStoreContext context) : base(context)
		{

		}

		public bool IsNameDuplicated(ProductGroup productGroup)
		{
			bool result;
			if (productGroup.Id > 0)
			{
				result = context.ProductGroups.Count(x => x.Name == productGroup.Name &&
																							x.Id != productGroup.Id
																							) > 0;
			}
			else
			{
				result = (context.ProductGroups.Count(x => x.Name == productGroup.Name)) > 0;
			}
			return result;
		}

		public bool ProductGroupExist(int id)
		{
			return context.ProductGroups.Count(x => x.Id == id) > 0;
		}
	}
}
