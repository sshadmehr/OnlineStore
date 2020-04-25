using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Respsitories
{
	public interface IDeliveryGroupRepository : IBaseEntityRepository<DeliveryGroup>
	{
		bool IsNameDuplicated(DeliveryGroup deliveryGroup);
		bool DeliveryGroupExist(int deliveryGroupId);
	}

}
