using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Repositories
{
	public interface IDeliveryGroupRepository : IBaseEntityRepository<DeliveryGroup>
	{
		bool IsNameDuplicated(DeliveryGroup deliveryGroup);
		bool DeliveryGroupExist(int deliveryGroupId);
	}

}
