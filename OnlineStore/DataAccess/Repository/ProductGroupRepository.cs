using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
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
			bool result = true;
			if (productGroup.Id > 0)
			{
				result = (context.ProductGroups.Where(x => x.Name == productGroup.Name &&
																							x.Id != productGroup.Id
																							)).Count() > 0;
			}
			else
			{
				result = (context.ProductGroups.Where(x => x.Name == productGroup.Name)).Count() > 0;
			}
			return result;
		}

		public bool ProductGroupExist(int id)
		{
			return context.ProductGroups.Where(x => x.Id == id).Count() > 0;
		}
	}
}
