using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Exceptions
{
	public class ApplicationException : Exception
	{
		public ApplicationException(List<string> messages) : base(string.Join(",", messages))
		{

		}
	}
}
