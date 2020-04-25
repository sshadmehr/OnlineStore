using OnlineStore.DataAccess;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using OnlineStore.Domain.Services;
using OnlineStore.Domain.Enums;
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
			if (DeleteValidate(tariff.Id, out List<string> messagaes))
			{
				_tariffRepository.Delete(tariff);
				_unitOfWork.Commit();
			}
			else
				throw new System.Exception(string.Join(",", messagaes));
		}

		public void Delete(int id)
		{
			if (DeleteValidate(id, out List<string> messagaes))
			{
				_tariffRepository.Delete(id);
				_unitOfWork.Commit();
			}
			else
				throw new System.Exception(string.Join(",", messagaes));
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
			if (SubmitValidate(tariff, out List<string> messagaes))
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
			else
				throw new System.Exception(string.Join(",", messagaes));
		}

		private bool SubmitValidate(Tariff tariff, out List<string> messagaes)
		{
			messagaes = new List<string>();

			if (tariff.DeliveryGroupId < 1)
				messagaes.Add("Delivery Group Is InValid.");

			if (tariff.EffectiveDate == null)
				messagaes.Add("EffectiveDate Can't be emty.");

			if (!_deliveryGroupRepository.DeliveryGroupExist(tariff.DeliveryGroupId))
				messagaes.Add("Delivery Group Does Not Exist.");

			if (System.Enum.IsDefined(typeof(DeliveryType), tariff.DeliveryType))
				messagaes.Add("Delivery Type Is Not Valid.");

			return messagaes.Count < 1;
		}

		private bool DeleteValidate(int id, out List<string> messagaes)
		{
			messagaes = new List<string>();
			return true;
		}
	}
}
