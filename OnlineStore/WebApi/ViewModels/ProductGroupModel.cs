using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.WebApi.ViewModels
{
	public class ProductGroupModel : BaseEntityModel
	{
		public Nullable<int> ParentId { get; set; }
	}
}
