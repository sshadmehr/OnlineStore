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
			if (DeleteValidate(deliveryGroup, out List<string> messagaes))
			{
				_deliveryGroupRepository.Delete(deliveryGroup);
				_unitOfWork.Commit();
			}
			else
				throw new System.Exception(string.Join(",", messagaes));
		}

		public void Delete(int id)
		{
			var deliveryGroup = this.Get(id);
			if (DeleteValidate(deliveryGroup, out List<string> messagaes))
			{
				_deliveryGroupRepository.Delete(id);
				_unitOfWork.Commit();
			}
			else
				throw new System.Exception(string.Join(",", messagaes));
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
			if (SubmitValidate(deliveryGroup, out List<string> messagaes))
			{
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
			else
				throw new System.Exception(string.Join(",", messagaes));
		}

		private bool SubmitValidate(DeliveryGroup deliveryGroup, out List<string> messagaes)
		{
			messagaes = new List<string>();

			if (string.IsNullOrEmpty(deliveryGroup.Name))
				messagaes.Add("DeliveryGroup Name Can't be emty.");

			if (_deliveryGroupRepository.IsNameDuplicated(deliveryGroup))
				messagaes.Add("DeliveryGroup Name Is Duplicate.");

			return messagaes.Count < 1;
		}
		private bool DeleteValidate(DeliveryGroup deliveryGroup, out List<string> messagaes)
		{
			messagaes = new List<string>();

			if (_productsDeliveryGroupsRepository.GetByDeliveryGroup(deliveryGroup.Id).Count() > 1)
				messagaes.Add("DeliveryGroup Is Used In Products And Can't Be Deleted.");

			return true;
		}

	}
}
