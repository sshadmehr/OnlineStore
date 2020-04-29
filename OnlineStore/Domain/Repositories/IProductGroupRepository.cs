using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Repositories
{
	public interface IProductGroupRepository : IBaseEntityRepository<ProductGroup>
	{
		bool ProductGroupExist(int id);
		bool IsNameDuplicated(ProductGroup productGroup);
	}

}
