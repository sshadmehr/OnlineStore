using OnlineStore.Domain.Models;
using OnlineStore.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using OnlineStore.Domain.Respsitories;
using OnlineStore.DataAccess;
using OnlineStore.Exceptions;

namespace OnlineStore.Services
{
	public class DeliveryGroupService : IDeliveryGroupService
	{
		public DeliveryGroupService(
			IDeliveryGroupRepository deliveryGroupRepository,
			IProductsDeliveryGroupsRepository productsDeliveryGroupsRepository,
			IUnitOfWork unitOfWork)
		{
			_deliveryGroupRepository = deliveryGroupRepository;
			_productsDeliveryGroupsRepository = productsDeliveryGroupsRepository;
			_unitOfWork = unitOfWork;
		}

		private readonly IDeliveryGroupRepository _deliveryGroupRepository;
		private readonly IProductsDeliveryGroupsRepository _productsDeliveryGroupsRepository;
		private readonly IUnitOfWork _unitOfWork;

		public void Delete(DeliveryGroup deliveryGroup)
		{
			DeleteValidate(deliveryGroup);
			_deliveryGroupRepository.Delete(deliveryGroup);
			_unitOfWork.Commit();
		}

		public void Delete(int id)
		{
			var deliveryGroup = this.Get(id);
			DeleteValidate(deliveryGroup);
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
			SubmitValidate(deliveryGroup);
			if (deliveryGroup.Id > 0)
			{
				_deliveryGroupRepository.Update(deliveryGroup);
			}
			else
			{
				_deliveryGroupRepository.Insert(deliveryGroup);
			}
			_unitOfWork.Commit();
		}

		private bool SubmitValidate(DeliveryGroup deliveryGroup)
		{
			var messages = new List<string>();

			if (string.IsNullOrEmpty(deliveryGroup.Name))
				messages.Add("DeliveryGroup Name Can't be emty.");

			if (_deliveryGroupRepository.IsNameDuplicated(deliveryGroup))
				messages.Add("DeliveryGroup Name Is Duplicate.");

			if (messages.Count > 0)
			{
				throw new ApplicationException(messages);
			}

			return true;
		}
		private bool DeleteValidate(DeliveryGroup deliveryGroup)
		{
			var messages = new List<string>();

			if (_productsDeliveryGroupsRepository.GetByDeliveryGroup(deliveryGroup.Id).Count() > 1)
				messages.Add("DeliveryGroup Is Used In Products And Can't Be Deleted.");

			if (messages.Count > 0)
			{
				throw new ApplicationException(messages);
			}

			return true;
		}

	}
}
