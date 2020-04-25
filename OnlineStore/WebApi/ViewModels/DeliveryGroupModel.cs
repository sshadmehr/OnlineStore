using System.Collections.Generic;

namespace OnlineStore.WebApi.ViewModels
{
	public class DeliveryGroupModel : BaseEntityModel
	{
		public DeliveryGroupModel()
		{
			ProductsDeliveryGroups = new HashSet<ProductsDeliveryGroupsModel>();
		}
		public ICollection<ProductsDeliveryGroupsModel> ProductsDeliveryGroups { get; set; }
	}
}
