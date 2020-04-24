using OnlineStore.DataAccess.Repository;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly OnlineStoreContext _dbContext;
		public UnitOfWork(OnlineStoreContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Commit()
		{
			_dbContext.SaveChanges();
		}
	}
}
