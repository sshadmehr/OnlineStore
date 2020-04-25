using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using System;
using System.Linq;

namespace OnlineStore.DataAccess.Repository
{
	public class DeliveryGroupRepository : BaseLogicalDeletableRepository<DeliveryGroup>, IDeliveryGroupRepository
	{
		public DeliveryGroupRepository(OnlineStoreContext context) : base(context)
		{

		}

		public bool IsNameDuplicated(DeliveryGroup deliveryGroup)
		{
			bool result = true;
			if (deliveryGroup.Id > 0)
			{
				result = (context.DeliveryGroups.Where(x => x.Name == deliveryGroup.Name &&
																							x.Id != deliveryGroup.Id
																							)).Count() > 0;
			}
			else
			{
				result = (context.DeliveryGroups.Where(x => x.Name == deliveryGroup.Name)).Count() > 0;
			}
			return result;
		}

	}
}
