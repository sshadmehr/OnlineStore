using Microsoft.EntityFrameworkCore;
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

		public bool ProductGroupExist(int id)
		{
			return context.ProductGroups.Where(x => x.Id == id).Count() > 0;
		}
	}
}
