using OnlineStore.DataAccess;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using OnlineStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Services
{
	public class TariffService : ITariffService
	{
		public TariffService(ITariffRepository tariffRepository, IUnitOfWork unitOfWork)
		{
			_tariffRepository = tariffRepository;
			_unitOfWork = unitOfWork;
		}

		private readonly ITariffRepository _tariffRepository;
		private readonly IUnitOfWork _unitOfWork;

		public void Delete(Tariff tariff)
		{
			_tariffRepository.Delete(tariff);
			_unitOfWork.Commit();
		}

		public void Delete(int id)
		{
			_tariffRepository.Delete(id);
			_unitOfWork.Commit();
		}

		public Tariff Get(int id)
		{
			return _tariffRepository.Get(id);
		}

		public IEnumerable<Tariff> GetAll()
		{
			return _tariffRepository.Get(); ;
		}

		public void Submit(Tariff tariff)
		{
			if (tariff.Id > 0)
			{
				_tariffRepository.Update(tariff);
			}
			else
			{
				_tariffRepository.Insert(tariff);
			}
			_unitOfWork.Commit();
		}
	}
}
