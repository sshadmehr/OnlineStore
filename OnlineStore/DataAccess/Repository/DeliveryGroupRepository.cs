using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Repositories;
using System.Linq;

namespace OnlineStore.DataAccess.Repository
{
	public class DeliveryGroupRepository : BaseLogicalDeletableRepository<DeliveryGroup>, IDeliveryGroupRepository
	{
		public DeliveryGroupRepository(OnlineStoreContext context) : base(context)
		{

		}

		public bool DeliveryGroupExist(int deliveryGroupId)
		{
			return context.DeliveryGroups.Count(x => x.Id == deliveryGroupId) > 0;
		}

		public bool IsNameDuplicated(DeliveryGroup deliveryGroup)
		{
			bool result;
			if (deliveryGroup.Id > 0)
			{
				result = context.DeliveryGroups.Where(x => x.Name == deliveryGroup.Name &&
																							x.Id != deliveryGroup.Id
																							).Any();
			}
			else
			{
				result = context.DeliveryGroups.Where(x => x.Name == deliveryGroup.Name).Any();
			}
			return result;
		}

	}
}
