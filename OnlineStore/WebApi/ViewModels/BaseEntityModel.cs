using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.WebApi.ViewModels
{
	public class BaseEntityModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool Deleted { get; set; }
	}
}
