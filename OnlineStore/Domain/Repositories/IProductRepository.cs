using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Respsitories
{
	public interface IProductRepository : IBaseEntityRepository<Product>
	{
		Product Load(int id);
		bool IsNameDuplicated(Product product);
		bool IsProductGroupUsed(int productGroupId);
	}

}
