using OnlineStore.DataAccess;
using OnlineStore.Domain.Enums;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Repositories;
using OnlineStore.Domain.Services;
using System;
using System.Collections.Generic;

namespace OnlineStore.Services
{
	public class TariffService : ITariffService
	{
		public TariffService(
			ITariffRepository tariffRepository,
			IDeliveryGroupRepository deliveryGroupRepository,
			IUnitOfWork unitOfWork)
		{
			_tariffRepository = tariffRepository;
			_deliveryGroupRepository = deliveryGroupRepository;
			_unitOfWork = unitOfWork;
		}

		private readonly ITariffRepository _tariffRepository;
		private readonly IDeliveryGroupRepository _deliveryGroupRepository;
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
			SubmitValidate(tariff);
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

		private void SubmitValidate(Tariff tariff)
		{
			var messages = new List<string>();

			if (tariff.DeliveryGroupId < 1)
				messages.Add("Delivery Group Is InValid.");

			if (tariff.EffectiveDate == null || tariff.EffectiveDate == DateTime.MinValue)
				messages.Add("EffectiveDate Can't be emty.");

			if (!_deliveryGroupRepository.DeliveryGroupExist(tariff.DeliveryGroupId))
				messages.Add("Delivery Group Does Not Exist.");

			if (System.Enum.IsDefined(typeof(DeliveryType), tariff.DeliveryType))
				messages.Add("Delivery Type Is Not Valid.");

			if (messages.Count > 0)
			{
				throw new Exceptions.ApplicationException(messages);
			}
		}
	}
}
