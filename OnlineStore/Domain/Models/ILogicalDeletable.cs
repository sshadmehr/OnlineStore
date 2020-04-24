using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Models
{
	public interface ILogicalDeletable
	{
		bool Deleted { get; set; }
	}
}
