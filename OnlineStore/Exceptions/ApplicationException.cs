using System;
using System.Collections.Generic;

namespace OnlineStore.Exceptions
{
	public class ApplicationException : Exception
	{
		public ApplicationException(IEnumerable<string> messages) : base(string.Join(",", messages))
		{

		}
	}
}
