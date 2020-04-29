using OnlineStore.Domain.Models;
using System.Collections.Generic;

namespace OnlineStore.Domain.Services
{
	public interface IDeliveryGroupService
	{
		DeliveryGroup Get(int id);
		IEnumerable<DeliveryGroup> GetAll(bool includeDeleted = false);
		void Submit(DeliveryGroup deliveryGroup);
		void Delete(DeliveryGroup deliveryGroup);
		void Delete(int id);
	}
}
