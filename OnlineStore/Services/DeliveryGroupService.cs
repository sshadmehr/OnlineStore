using OnlineStore.Domain.Models;
using OnlineStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Domain.Respsitories;
using OnlineStore.DataAccess;

namespace OnlineStore.Services
{
	public class DeliveryGroupService : IDeliveryGroupService
	{
		public DeliveryGroupService(IDeliveryGroupRepository deliveryGroupRepository, IUnitOfWork unitOfWork)
		{
			_deliveryGroupRepository = deliveryGroupRepository;
			_unitOfWork = unitOfWork;
		}

		private readonly IDeliveryGroupRepository _deliveryGroupRepository;
		private readonly IUnitOfWork _unitOfWork;

		public void Delete(DeliveryGroup deliveryGroup)
		{
			_deliveryGroupRepository.Delete(deliveryGroup);
			_unitOfWork.Commit();
		}

		public void Delete(int id)
		{
			_deliveryGroupRepository.Delete(id);
			_unitOfWork.Commit();
		}

		public DeliveryGroup Get(int id)
		{
			return _deliveryGroupRepository.Get(id);
		}

		public IEnumerable<DeliveryGroup> GetAll(bool includeDeleted = false)
		{
			var result = new List<DeliveryGroup>();

			if (includeDeleted)
				result = _deliveryGroupRepository.Get()?.ToList();
			else
				result = _deliveryGroupRepository.Get(dg => dg.Deleted == includeDeleted)?.ToList();

			return result;
		}

		public void Submit(DeliveryGroup deliveryGroup)
		{
			if(deliveryGroup.Id > 0)
			{
				_deliveryGroupRepository.Update(deliveryGroup);
			}
			else
			{
				_deliveryGroupRepository.Insert(deliveryGroup);
			}
			_unitOfWork.Commit();
		}
	}
}
