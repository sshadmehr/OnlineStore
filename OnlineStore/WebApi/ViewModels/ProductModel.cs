using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.WebApi.ViewModels
{
	public class ProductModel : BaseEntityModel
	{
		public ProductModel()
		{
			ProductsDeliveryGroups = new HashSet<ProductsDeliveryGroupsModel>();
		}
		public string Model { get; set; }
		public DateTime RegisterDate { get; set; }
		public int ProductGroupId { get; set; }
		public ProductGroupModel ProductGroup { get; set; }
		public ICollection<ProductsDeliveryGroupsModel> ProductsDeliveryGroups { get; set; }
		
	}
}
