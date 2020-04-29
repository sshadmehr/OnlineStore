using OnlineStore.Domain.Models;
using System.Collections.Generic;

namespace OnlineStore.Domain.Services
{
	public interface IProductGroupService
	{
		ProductGroup Get(int id);
		IEnumerable<ProductGroup> GetAll(bool includeDeleted = false);
		void Submit(ProductGroup productGroup);
		void Delete(ProductGroup productGroup);
		void Delete(int id);
	}
}
