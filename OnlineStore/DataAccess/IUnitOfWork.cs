using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess
{
	public interface IUnitOfWork
	{
		void Commit();
	}
}
