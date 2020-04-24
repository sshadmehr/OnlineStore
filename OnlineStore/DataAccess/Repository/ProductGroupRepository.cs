using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;

namespace OnlineStore.DataAccess.Repository
{
	public class ProductGroupRepository : BaseLogicalDeletableRepository<ProductGroup>, IProductGroupRepository
	{
		public ProductGroupRepository(OnlineStoreContext context) : base(context)
		{

		}

	}
}
