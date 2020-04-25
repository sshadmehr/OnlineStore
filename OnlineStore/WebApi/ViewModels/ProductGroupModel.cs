using System;

namespace OnlineStore.WebApi.ViewModels
{
	public class ProductGroupModel : BaseEntityModel
	{
		public Nullable<int> ParentId { get; set; }
	}
}
