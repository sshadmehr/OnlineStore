using OnlineStore.Domain.Dtos;
using OnlineStore.Domain.Models;
using System.Collections.Generic;

namespace OnlineStore.Domain.Services
{
	public interface IProductService
	{
		Product Get(int id);
		IEnumerable<Product> GetAll(bool includeDeleted = false);
		void Submit(Product product);
		void Delete(Product product);
		void Delete(int id);
		int GetMinimumProductTariff(int productId);
		IEnumerable<ProductTariffDto> GetProductTariffList(IEnumerable<int> ids);
	}
}
