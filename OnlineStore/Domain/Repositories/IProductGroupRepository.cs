using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Respsitories
{
	public interface IProductGroupRepository : IBaseEntityRepository<ProductGroup>
	{
		bool ProductGroupExist(int id);
		bool IsNameDuplicated(ProductGroup productGroup);
	}

}
