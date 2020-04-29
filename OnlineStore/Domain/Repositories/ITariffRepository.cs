using OnlineStore.Domain.Dtos;
using OnlineStore.Domain.Models;
using System.Collections.Generic;

namespace OnlineStore.Domain.Repositories
{
	public interface ITariffRepository : IBaseEntityRepository<Tariff>
	{
		int GetMinTariff(int productId);
		IEnumerable<ProductTariffDto> GetProductTariffList(IEnumerable<int> productIds);
	}

}
