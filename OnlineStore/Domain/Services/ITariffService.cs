using OnlineStore.Domain.Models;
using System.Collections.Generic;

namespace OnlineStore.Domain.Services
{
	public interface ITariffService
	{
		Tariff Get(int id);
		IEnumerable<Tariff> GetAll();
		void Submit(Tariff tariff);
		void Delete(Tariff tariff);
		void Delete(int id);
	}
}
