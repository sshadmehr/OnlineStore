using System.Collections.Generic;
using OnlineStore.Domain.Dtos;
using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Respsitories
{
	public interface ITariffRepository : IBaseEntityRepository<Tariff>
	{
		int GetMinTariff(int productId);
		IEnumerable<ProductTariffDto> GetProductTariffList(IEnumerable<int> productIds);
	}

}
