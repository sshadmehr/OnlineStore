using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
